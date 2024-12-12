namespace ProApiFull.Api.Controllers;

public partial class UsersController
{

    [HttpGet(nameof(GetById))]
    public async Task<IActionResult> GetById(string Id)
    {
        var users = await userService.GetAsync(Id);

        return users.IsSuccess ? Ok(users.Value) : BadRequest(users.Error);

    }
}
