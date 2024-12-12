namespace ProApiFull.Api.Controllers;

public partial class UsersController
{
    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await userService.GetAllAsync(cancellationToken);
        return Ok(users);
    }
}
