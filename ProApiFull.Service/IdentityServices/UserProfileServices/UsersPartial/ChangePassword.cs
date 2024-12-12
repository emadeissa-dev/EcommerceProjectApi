namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<string> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await userManager.FindByIdAsync(userId);
        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
            return string.Join(",", result.Errors.ToList());
        return "the password is changed successfully";
    }
}
