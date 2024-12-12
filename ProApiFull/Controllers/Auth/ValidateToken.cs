namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("Validate-Token")]
    public async Task<IActionResult> ValidateToken([FromBody] string request, CancellationToken cancellationToken)
    {
        var (userId, expiryOn) = _jwtProvider.ValidateTokenExpiryDate(request);
        return userId == null ? BadRequest("InValid Token") : Ok(new { UserId = userId, ExpiryDate = expiryOn });
    }
}
