namespace ProApiFull.Service.IdentityServices;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<string> permissions);
    string? ValidateToken(string token);
    (string, string) ValidateTokenExpiryDate(string token);
}