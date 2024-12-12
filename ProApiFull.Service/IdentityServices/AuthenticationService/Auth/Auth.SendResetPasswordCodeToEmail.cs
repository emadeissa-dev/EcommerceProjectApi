namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result> SendResetPasswordCodeToEmailAsync(string email)
    {
        if (await _userManager.FindByEmailAsync(email) is not { } user)
            return Unauthorized<Result>("error email");

        if (!user.EmailConfirmed)
            return Unauthorized<Result>("email is not confirmed"); ;


        var code = await GenerateCodeToResetPassword(user);

        await SendUrlActionPasswordToClick(user, code!);

        return Result.Success();
    }
}
