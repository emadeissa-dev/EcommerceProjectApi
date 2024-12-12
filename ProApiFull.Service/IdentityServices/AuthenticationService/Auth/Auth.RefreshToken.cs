
namespace ProApiFull.Service.IdentityServices;
public partial class AuthService
{
    public async Task<Result<AuthResponse?>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId == null)
            return Unauthorized<AuthResponse?>("invalied token");


        var user = await _userManager.FindByIdAsync(userId);
        if (userId == null)
            return Unauthorized<AuthResponse?>("invalied token !!");

        if (user.IsDeleted)
            return UnprocessableEntity<AuthResponse?>("user is dasable");

        var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);
        if (userRefreshToken == null)
            return Unauthorized<AuthResponse?>("Refresh Tokens error");

        userRefreshToken.RevokeOn = DateTime.UtcNow;



        var (userRoles, rolePermissions) = await GenerateUserRolesPermissions(user, cancellationToken);

        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, rolePermissions!);

        var newRefreshToken = GenrateRefreshToken();
        var refreshTokenExpiryDate = DateTime.UtcNow.AddDays(_RefreshTokenExpirition);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpireOn = refreshTokenExpiryDate
        });

        await _userManager.UpdateAsync(user);

        var authResponse = new AuthResponse
        {
            Id = user.Id,
            Email = user.Email!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = newToken,
            ExpireIn = expiresIn,
            RefreshToken = newRefreshToken,
            RefreshTokenExpirtion = refreshTokenExpiryDate
        };

        return Result.Success(authResponse)!;
    }
}
