namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        if (await _userManager.FindByEmailAsync(email) is not { } user)
            return BadRequest<AuthResponse>("invalid user name or password");


        // var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
        var result = await signInManager.PasswordSignInAsync(user, password, false, true);

        if (!user.EmailConfirmed)
            return Unauthorized<AuthResponse>("email is not confirmed !");

        if (user.IsDeleted)
            return Unauthorized<AuthResponse>("email is disable !");


        if (result.IsLockedOut)
            return Unauthorized<AuthResponse>("email Is Locked Out !");

        if (!result.Succeeded)
            return Unauthorized<AuthResponse>("failed to login !");


        var authResponse = await GenerateTokenWithRefreshToken(user);

        return Result.Success(authResponse);
    }
}
