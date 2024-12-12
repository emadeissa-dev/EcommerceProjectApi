using ProApiFull.Service.Contract.Roles;

namespace ProApiFull.Service.IdentityServices;
public partial class RoleService
{
    public async Task<Result<RoleDetailResponse>> CreateAsync(RoleRequest request)
    {
        var roleExist = await roleManager.RoleExistsAsync(request.Name);
        if (roleExist)
            return Duplicated<RoleDetailResponse>("this role is exist before");

        var allPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allPermissions).Any())
            return BadRequest<RoleDetailResponse>("role not allowed"); ;

        var role = new ApplicationRole
        {
            Name = request.Name,
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var result = await roleManager.CreateAsync(role);
        if (result.Succeeded)
        {
            var permmsions = request.Permissions
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    RoleId = role.Id,
                    ClaimValue = x

                });
            await context.AddRangeAsync(permmsions);

            await context.SaveChangesAsync();
            var response = new RoleDetailResponse
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = request.Permissions,
                IsDeleted = role.IsDeleted
            };
            return Result.Success(response);

        }

        return BadRequest<RoleDetailResponse>("Creating Error"); ;

    }
}
