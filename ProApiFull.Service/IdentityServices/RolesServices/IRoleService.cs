using ProApiFull.Service.Contract;
using ProApiFull.Service.Contract.Roles;

namespace ProApiFull.Service.IdentityServices;
public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool? includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailResponse>> GetAsync(string Id);
    Task<Result<RoleDetailResponse>> CreateAsync(RoleRequest request);
    Task<Result<RoleDetailResponse>> UpdateAsync(string Id, RoleRequest request);
    Task<Result<RoleResponse>> ToggleStatusAsync(string Id);
}
