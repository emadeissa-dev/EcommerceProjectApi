namespace ProApiFull.Service.Seeds
{
    public static class GenrateDefaultUsers
    {

        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
        {

            var defaultUser = new ApplicationUser
            {

                FirstName = "member",
                LastName = "member1",
                UserName = "member@gmail.com",
                NormalizedUserName = "member@gmail.com".ToUpper(),
                Email = "member@gmail.com",
                NormalizedEmail = "member@gmail.com".ToUpper(),
                SecurityStamp = DefaultUsers.AdminSecurityStamp,
                ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Mm@123123");
                await userManager.AddToRoleAsync(defaultUser, DefaultRoles.Member);
            }
        }

        public static async Task SeedSuperAdminUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManger)
        {
            var defaultUser = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin1",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                SecurityStamp = DefaultUsers.AdminSecurityStamp,
                ConcurrencyStamp = DefaultUsers.AdminConcurrencyStamp,
                EmailConfirmed = true,
                LockoutEnabled = false,

            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Mm@123123");
                await userManager.AddToRolesAsync(defaultUser, new List<string> { DefaultRoles.Member, DefaultRoles.Admin });
            }

            await roleManger.SeedClaimsForSuperUser();
        }

        private static async Task SeedClaimsForSuperUser(this RoleManager<ApplicationRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(DefaultRoles.Admin);
            var permmsions = Permissions.GetAllPermissions();
            foreach (var perimssion in permmsions)
                await roleManager.AddPermissionClaims(adminRole, perimssion);
        }

        private static async Task AddPermissionClaims(this RoleManager<ApplicationRole> roleManager, ApplicationRole role, string perimssion)
        {
            var allClaimdRole = await roleManager.GetClaimsAsync(role);

            if (!allClaimdRole.Any(c => c.Type == Permissions.Type && c.Value == perimssion))
                await roleManager.AddClaimAsync(role, new Claim(Permissions.Type, perimssion));

        }

    }
}