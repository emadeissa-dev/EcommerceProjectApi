namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<bool> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId == null)
            return false;


        var user = await _userManager.FindByIdAsync(userId);
        if (userId == null)
            return false;

        var userRefreshToken = user!.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);
        if (userRefreshToken == null)
            return false;

        userRefreshToken.RevokeOn = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return true;
    }

}
