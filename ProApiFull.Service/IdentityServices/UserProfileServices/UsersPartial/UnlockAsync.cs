namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<Result> UnlockAsync(string Id)
    {

        if (await userManager.FindByIdAsync(Id) is not { } user)
            return NotFound();

        var result = await userManager.SetLockoutEndDateAsync(user, null);

        if (result.Succeeded)
            return Success();

        var errors = string.Join(",", result.Errors.Select(x => x.Description).ToList());

        return BadRequest(errors);

    }
}
