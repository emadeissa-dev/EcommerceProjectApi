namespace ProApiFull.Service.IdentityServices;
public partial class RoleService
{
    public async Task<Result<RoleResponse>> ToggleStatusAsync(string Id)
    {
        if (await roleManager.FindByIdAsync(Id) is not { } role)
            return NotFound<RoleResponse>();

        role.IsDeleted = !role.IsDeleted;
        await roleManager.UpdateAsync(role);
        return Success(new RoleResponse
        {
            Id = role.Id,
            Name = role.Name!,
            IsDeleted = role.IsDeleted
        });
    }
}
