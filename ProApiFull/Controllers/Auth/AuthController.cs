namespace ProApiFull.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class AuthController : AppControllerBase
{
    private readonly IAuthService _authService;
    private readonly IJwtProvider _jwtProvider;
    public AuthController(IAuthService authService, IJwtProvider jwtProvider)
    {
        _authService = authService;
        _jwtProvider = jwtProvider;
    }




}
