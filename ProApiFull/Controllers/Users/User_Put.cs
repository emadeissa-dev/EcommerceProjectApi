namespace ProApiFull.Api.Controllers;

public partial class UsersController
{
    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update(string Id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var users = await userService.UpdateAsync(Id, request, cancellationToken);
        return users.IsSuccess ? Ok(users.Value) : BadRequest(users.Error);

    }
    [HttpPut(nameof(ToggleStatus))]
    public async Task<IActionResult> ToggleStatus(string Id, CancellationToken cancellationToken)
    {
        var users = await userService.ToggleStatusAsync(Id, cancellationToken);
        return users.IsSuccess ? Ok() : BadRequest(users.Error);

    }
    [HttpPut(nameof(UnlockUser))]
    public async Task<IActionResult> UnlockUser(string Id)
    {
        var users = await userService.UnlockAsync(Id);
        return users.IsSuccess ? Ok() : BadRequest(users.Error);

    }
}
