namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<Result<UserResponse>> GetAsync(string userId)
    {

        #region First Way
        //if (await userManager.FindByIdAsync(userId) is not { } user)
        //    return Result.Failure<UserResponse>(UserErrors.NotFound);

        //var roles = await userManager.GetRolesAsync(user);

        //var response = new UserResponse
        //{
        //    Id = user.Id,
        //    FirstName = user.FirstName,
        //    LastName = user.LastName,
        //    Email = user.Email,
        //    IsDisabled = user.IsDisabled,
        //    Roles = roles
        //};

        //return Result.Success(response);
        #endregion

        if (await userManager.FindByIdAsync(userId) is not { } user)
            return NotFound<UserResponse>();

        var userRoles = await userManager.GetRolesAsync(user);

        var response = (user, userRoles).Adapt<UserResponse>();

        return Success(response);

    }
}
