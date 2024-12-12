namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task UpdateProfileAsync(string userId, UpdateProfileRequestUser request)
    {
        //var user = await userManager.FindByIdAsync(userId);
        //user = requestUser.Adapt(user);
        //await userManager.UpdateAsync(user!);

        await userManager.Users.Where(x => x.Id == userId)
            .ExecuteUpdateAsync(setters =>

                setters.SetProperty(u => u.FirstName, request.FirstName)
               .SetProperty(u => u.LastName, request.LastName)
           );
    }
}
