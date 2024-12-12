namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Success();

        if (user.EmailConfirmed)
            return Unauthorized<Result>("email is not confirmed");

        var code = await GenerateCodeToConfirmEmail(user);


        await SendUrlActionToConfirmEmail(user, code);


        return Result.Success();
    }
}
