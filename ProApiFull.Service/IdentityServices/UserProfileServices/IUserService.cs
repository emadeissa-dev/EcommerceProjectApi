namespace ProApiFull.Service.IdentityServices;
public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<UserResponse>> GetAsync(string userId);
    Task<UserProfileResponse> GetUserProfileAsync(string userId);
    Task UpdateProfileAsync(string userId, UpdateProfileRequestUser requestUser);
    Task<string> ChangePasswordAsync(string userId, ChangePasswordRequest request);
    Task<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<Result<UserResponse>> UpdateAsync(string Id, UpdateUserRequest request, CancellationToken cancellationToken);
    Task<Result> ToggleStatusAsync(string Id, CancellationToken cancellationToken);
    Task<Result> UnlockAsync(string Id);
}
