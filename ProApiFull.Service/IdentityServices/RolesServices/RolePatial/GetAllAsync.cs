namespace ProApiFull.Service.IdentityServices;
public partial class RoleService
{
    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return await roleManager.Roles
            .Where(x => !x.IsDeleted && (!x.IsDeleted || includeDeleted == true))
            .ProjectToType<RoleResponse>()
            .ToListAsync();
    }
}
