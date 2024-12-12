namespace ProApiFull.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public partial class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }




}
