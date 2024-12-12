
namespace ProApiFull.Service.Seeds
{
    public static class GeranteDefaultRoles
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManger)
        {
            string[] roles = [DefaultRoles.Admin, DefaultRoles.Member];
            foreach (var role in roles)
            {
                if (!await roleManger.RoleExistsAsync(role))
                    await roleManger.CreateAsync(new ApplicationRole { Name = role, IsDeleted = false });
            }
        }
    }
}
