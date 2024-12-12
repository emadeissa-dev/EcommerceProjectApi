namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("Refresh-Token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
        return authResult is null ? BadRequest("InValid User Name Or Password") : Ok(authResult);
    }
}
