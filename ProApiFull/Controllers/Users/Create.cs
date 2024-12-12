namespace ProApiFull.Api.Controllers;

public partial class UsersController
{
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var users = await userService.CreateAsync(request, cancellationToken);

        return users.IsSuccess ? Ok(users.Value) : BadRequest(users.Error);

    }
}
