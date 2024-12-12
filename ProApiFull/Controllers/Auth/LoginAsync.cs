namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("LoginAsync")]

    public async Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);
        return authResult.IsSuccess ? Ok(authResult.Value) : BadRequest(authResult.Error);
    }
}
