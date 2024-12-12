namespace ProApiFull.Service.IdentityServices;
public partial class UserService
{
    public async Task<UserProfileResponse> GetUserProfileAsync(string userId)
    {
        var user = await userManager.Users
            .Where(x => x.Id == userId)
            .ProjectToType<UserProfileResponse>()
            .FirstAsync();

        return user;
    }
}
