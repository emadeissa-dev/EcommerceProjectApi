namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{

    public async Task<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var emailIsexists = await userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (emailIsexists)
            return Duplicated<UserResponse>();

        var allowedRoles = await roleService.GetAllAsync(true, cancellationToken);

        var exceptedRoles = request.Roles.Except(allowedRoles.Select(x => x.Name)).Any();
        if (exceptedRoles)
            return Failed<UserResponse>("role is not allowed");

        var user = request.Adapt<ApplicationUser>();
        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRolesAsync(user, request.Roles);
            var response = (user, request.Roles).Adapt<UserResponse>();
            return Result.Success(response);
        }
        var errors = result.Errors.Select(x => x.Description).ToList();
        return Result.Failure<UserResponse>
            (new Error("error", string.Join('-', errors), 500));


    }
}
