using ProApiFull.Service.Contract.Roles;

namespace ProApiFull.Service.IdentityServices;
public partial class RoleService
{
    public async Task<Result<RoleDetailResponse>> GetAsync(string Id)
    {
        if (await roleManager.FindByIdAsync(Id) is not { } role)
            return NotFound<RoleDetailResponse>();

        var permissions = await roleManager.GetClaimsAsync(role);

        var response = new RoleDetailResponse()
        {
            Id = role.Id,
            Name = role.Name,
            IsDeleted = role.IsDeleted,
            Permissions = permissions.Select(x => x.Value)
        };

        return Success(response);

    }
}
