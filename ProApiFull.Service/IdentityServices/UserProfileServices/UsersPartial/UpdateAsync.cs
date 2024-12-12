namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<Result<UserResponse>> UpdateAsync(string Id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var emailIsexists = await userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != Id, cancellationToken);
        if (emailIsexists)
            return Duplicated<UserResponse>("email is exist before");

        if (await userManager.FindByIdAsync(Id) is not { } user)
            return NotFound<UserResponse>();

        var allowedRoles = await roleService.GetAllAsync(true, cancellationToken);

        var exceptedRoles = request.Roles.Except(allowedRoles.Select(x => x.Name)).Any();
        if (exceptedRoles)
            return NotFound<UserResponse>("not allowed");

        user = request.Adapt(user);

        var result = await userManager.UpdateAsync(user);

        if (result.Succeeded)
        {

            #region Anather Way
            //var userRoles = await userManager.GetRolesAsync(user);
            //var removedRoles = await userManager.RemoveFromRolesAsync(user, userRoles);
            // await userManager.AddToRolesAsync(user, request.Roles);
            #endregion
            await context.UserRoles.Where(x => x.UserId == Id)
                .ExecuteDeleteAsync(cancellationToken);

            await userManager.AddToRolesAsync(user, request.Roles);
            var response = (user, request.Roles).Adapt<UserResponse>();
            return Success(response);
        }
        var errors = result.Errors.Select(x => x.Description).ToList();
        return BadRequest<UserResponse>(string.Join('-', errors));



    }

}
