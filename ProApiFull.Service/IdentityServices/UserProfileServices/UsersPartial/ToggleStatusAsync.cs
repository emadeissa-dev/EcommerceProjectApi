namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{

    public async Task<Result> ToggleStatusAsync(string Id, CancellationToken cancellationToken)
    {
        if (await userManager.FindByIdAsync(Id) is not { } user)
            return NotFound();

        await context.Users.Where(x => x.Id == Id)
            .ExecuteUpdateAsync(x => x
            .SetProperty(x => x.IsDeleted, x => !x.IsDeleted), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return Success();
    }

}
