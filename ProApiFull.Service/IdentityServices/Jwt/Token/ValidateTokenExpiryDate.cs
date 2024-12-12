namespace ProApiFull.Service.IdentityServices;

public partial class JwtProvider
{
    public (string, string) ValidateTokenExpiryDate(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = symmetricSecurityKey,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var userId = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
            var expireOn = jwtToken.ValidTo;

            return (userId, expireOn.ToString("yyyy-MM-dd : ss-mm-hh"));
        }
        catch
        {
            return (null!, null!);
        }

    }
}
