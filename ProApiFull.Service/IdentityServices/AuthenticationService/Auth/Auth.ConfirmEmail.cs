namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request)
    {
        if (await _userManager.FindByIdAsync(request.UserId) is not { } user)
            return NotFound<Result>();
        if (user.EmailConfirmed)
            return UnprocessableEntity<Result>("email is not confirmed");
        var code = request.Code;
        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }
        catch (FormatException ex)
        {
            return CodeError<Result>("code is error");
        }
        var result = await _userManager.ConfirmEmailAsync(user, code);
        return result.Succeeded ? Result.Success() : Failed<Result>("Failed To Confirm Email");
    }
}
