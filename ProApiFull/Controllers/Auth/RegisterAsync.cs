namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.RegisterAsync(request);
        return authResult.IsSuccess ? Ok(authResult.Value) : ToProblem(authResult);
    }
}
