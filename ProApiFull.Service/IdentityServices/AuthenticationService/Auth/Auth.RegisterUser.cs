namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request)
    {
        var emailExist = await _userManager.FindByEmailAsync(request.Email!);
        if (emailExist is not null)
            return Duplicated<AuthResponse>("email is exist before");

        var user = mapper.Map<ApplicationUser>(request);


        var result = await _userManager.CreateAsync(user, request.Password);


        var stringErrors = string.Join("\n =", result.Errors.Select(x => x.Description).ToList());
        if (!result.Succeeded)
            return Unauthorized<AuthResponse>(stringErrors);


        var authResponse = await GenerateTokenWithRefreshToken(user);

        await _userManager.AddToRoleAsync(user, DefaultRoles.Member);

        var code = await GenerateCodeToConfirmEmail(user);
        await SendUrlActionToConfirmEmail(user, code);
        return Result.Success(authResponse);
    }
}
