using FluentValidation.AspNetCore;
using HandlingFiles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProApiFull.Service.IdentityServices;
using ProApiFull.Service.IdentityServices.AuthenticationService.Filters;
using ProApiFull.Service.Seeds;
using ProApiFull.Service.Services.CategoryServies;
using System.Reflection;

namespace ProApiFull.Service;
public static class DependencesService
{
    public static IServiceCollection AddDependencesService(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IEmailsService, EmailsService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IDistributedMemoryServives, DistributedMemoryServives>();
        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        // Auto Mapper
        services.AddAutoMapper(typeof(DependencesService).Assembly);

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddDistributedMemoryCache();

        return services;
    }
    public static async Task<WebApplication> AddDependencesServicePipeLine(this WebApplication app)
    {

        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;




        try
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            await GeranteDefaultRoles.SeedAsync(roleManager);
            await GenrateDefaultUsers.SeedBasicUserAsync(userManager);
            await GenrateDefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);

        }
        catch (Exception)
        {

        }

        return app;

    }
}
