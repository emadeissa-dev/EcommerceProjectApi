namespace ProApiFull.Api.Controllers;

public partial class AuthController
{
    [HttpPost("ForgetPassword")]
    public async Task<IActionResult> ResetPasswordEmail([FromBody] ForgetPasswordRequest request, CancellationToken cancellationToken)
    {
        var result = await _authService.SendResetPasswordCodeToEmailAsync(request.Email);
        return result.IsSuccess ? Ok(result) : ToProblem(result);
    }
}
