


namespace ProApiFull.Api.ExetentionServives.SubConfigrations.IServiceCollections.Authentications;

public static class AuthenticationJWTConfig
{
    public static IServiceCollection AddAuthenticationJWTConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();


        services.Configure<EmailSettings>(configuration.GetSection("emailSettings"));

        services.AddOptions<JwtOptions>()
             .BindConfiguration(JwtOptions.SectionName)
             .ValidateDataAnnotations()
             .ValidateOnStart();

        var settings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings!.Key)),
                ValidIssuer = settings!.Issuer,
                ValidAudience = settings.Audience
            };
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            //options.Password.RequireNonAlphanumeric = false;
            //options.Password.RequireLowercase = false;
            //options.Password.RequireDigit = false;
            //options.Password.RequireUppercase = false;


            //options.Lockout.AllowedForNewUsers = true;
            //options.Lockout.MaxFailedAccessAttempts = 5;
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            options.SignIn.RequireConfirmedEmail = true;
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

        });




        return services;
    }
}
