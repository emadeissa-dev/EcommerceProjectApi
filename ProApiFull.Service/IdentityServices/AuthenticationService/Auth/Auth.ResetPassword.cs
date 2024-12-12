namespace ProApiFull.Service.IdentityServices;

public partial class AuthService
{
    public async Task<Result> ResetPasswordAsync(ResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null || !user.EmailConfirmed)
            return CodeError<Result>("Error Code");

        IdentityResult result;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            result = await _userManager.ResetPasswordAsync(user, code, request.NewPassword);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(_userManager.ErrorDescriber.InvalidToken());
        }

        if (result.Succeeded)
            return Result.Success();

        var errors = result.Errors.Select(x => x.Description).ToList();
        return Result.Failure(
            new Error(result.Errors.First().Code, string.Join("-", errors
           ), StatusCodes.Status500InternalServerError));
    }
}
