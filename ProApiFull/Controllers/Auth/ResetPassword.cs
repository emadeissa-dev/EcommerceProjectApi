namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        await _authService.ResetPasswordAsync(request);
        return Ok();
    }
}
