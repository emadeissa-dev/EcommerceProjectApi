namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
    {
        var result = await _authService.ConfirmEmailAsync(request);
        return result.IsSuccess ? Ok(result) : ToProblem(result);

    }
}
