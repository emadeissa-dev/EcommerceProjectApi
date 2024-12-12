

namespace ProApiFull.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IUserService userService;

    public AccountsController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpGet(nameof(GetUserProfile))]
    public async Task<IActionResult> GetUserProfile()
    {
        //var e = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        //var r = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
        //var m = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

        //var se = User.IsInRole("User");
        //var ed = User.FindAll("User");
        //var rt = User.Identity.Name;
        //var ee = User.HasClaim(ClaimTypes.Role, "User");
        //var we = User.FindFirst(ClaimTypes.NameIdentifier);


        var userId = User.ExGetCurrentUserId();
        var user = await userService.GetUserProfileAsync(userId!);
        return Ok(user);
    }

    [HttpPut(nameof(UpdateUserProfile))]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateProfileRequestUser request)
    {
        var userId = User.ExGetCurrentUserId();
        await userService.UpdateProfileAsync(userId!, request);
        return Ok();
    }
    [HttpPut(nameof(ChangePassword))]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userId = User.ExGetCurrentUserId();
        var result = await userService.ChangePasswordAsync(userId!, request);
        return Ok(result.ExTitleCase());
    }
}
