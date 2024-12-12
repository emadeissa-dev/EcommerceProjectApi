namespace ProApiFull.Api.Controllers;

public partial class AuthController
{

    [HttpPut("Revoke-Token")]
    public async Task<IActionResult> RevokeToken(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
        return !authResult ? BadRequest("Invalid Revoke Token") : Ok(authResult);
    }
}
