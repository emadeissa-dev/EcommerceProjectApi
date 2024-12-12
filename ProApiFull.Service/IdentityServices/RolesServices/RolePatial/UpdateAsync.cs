using ProApiFull.Service.Contract.Roles;

namespace ProApiFull.Service.IdentityServices;
public partial class RoleService
{
    public async Task<Result<RoleDetailResponse>> UpdateAsync(string Id, RoleRequest request)
    {
        var roleExist = await roleManager.Roles.AnyAsync(x => x.Name == request.Name && x.Id != Id);
        if (roleExist)
            return Duplicated<RoleDetailResponse>("this name assign to anather name");

        if (await roleManager.FindByIdAsync(Id) is not { } role)
            return NotFound<RoleDetailResponse>("this role is not found");

        var allPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allPermissions).Any())
            return BadRequest<RoleDetailResponse>("this permission not allowed");

        role.Name = request.Name;

        var updateRole = await roleManager.UpdateAsync(role);


        if (updateRole.Succeeded)
        {

            #region First Way


            var currentPermissions = await context.RoleClaims
                .Where(x => x.RoleId == Id && x.ClaimType == Permissions.Type)
                .Select(x => x.ClaimValue)
                .ToListAsync();

            var newPermissions = request.Permissions.Except(currentPermissions)
                .Select(x => new IdentityRoleClaim<string>
                {
                    ClaimType = Permissions.Type,
                    RoleId = role.Id,
                    ClaimValue = x

                });

            var removedPermissions = currentPermissions.Except(request.Permissions);

            await context.RoleClaims
                .Where(x => x.RoleId == Id && removedPermissions.Contains(x.ClaimValue))
                .ExecuteDeleteAsync();

            await context.AddRangeAsync(newPermissions);
            await context.SaveChangesAsync();


            var response = new RoleDetailResponse
            {
                Id = role.Id,
                Name = role.Name,
                Permissions = request.Permissions,
                IsDeleted = role.IsDeleted
            };
            #endregion

            #region Anather Way


            //var claimsforRole = await context.RoleClaims.Where(x => x.RoleId == role.Id).ToListAsync();
            //context.RemoveRange(claimsforRole);


            //var permmsions = request.Permissions
            // .Select(x => new IdentityRoleClaim<string>
            // {
            //     ClaimType = Permissions.Type,
            //     RoleId = role.Id,
            //     ClaimValue = x
            // });
            //await context.AddRangeAsync(permmsions);
            //await context.SaveChangesAsync();

            //var response = new RoleDetailResponse
            //{
            //    Id = role.Id,
            //    Name = role.Name,
            //    Permissions = request.Permissions,
            //    IsDeleted = role.IsDeleted
            //};
            #endregion




            return Success(response);
        }

        return Duplicated<RoleDetailResponse>("error in creation");


    }

}
