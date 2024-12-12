

namespace ProApiFull.Service.IdentityServices;

public partial class AuthService : ResponseError, IAuthService
{

    private readonly IUrlHelper _urlHelper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ILogger<AuthService> logger;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IEmailsService emailsService;
    private readonly IHttpContextAccessor httpContext;
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(
           IUrlHelper urlHelper,
        UserManager<ApplicationUser> userManager,
        IJwtProvider jwtProvider,
         RoleManager<ApplicationRole> roleManager,
         ILogger<AuthService> logger,
         SignInManager<ApplicationUser> signInManager,
         IEmailsService emailsService,
         IHttpContextAccessor httpContextAccessor,
         ApplicationDbContext context,
         IMapper mapper

        )
    {

        _userManager = userManager;
        _roleManager = roleManager;
        this.logger = logger;
        this.signInManager = signInManager;
        this.emailsService = emailsService;
        httpContext = httpContextAccessor;
        this.context = context;
        this.mapper = mapper;
        _jwtProvider = jwtProvider;
        _urlHelper = urlHelper;
    }

    private readonly int _RefreshTokenExpirition = 2;
    private async Task<(IEnumerable<string>, IEnumerable<string>)> GenerateUserRolesPermissions(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        //var rolePermissions = await context.Roles
        //    .Join(context.RoleClaims,
        //    role => role.Id,
        //    claim => claim.RoleId,
        //    (role, claim) => new { role, claim }
        //    ).Where(x => userRoles.Contains(x.role.Name))
        //    .Select(x => x.claim.ClaimValue)
        //       .Distinct()
        //    .ToListAsync(cancellationToken);

        var rolePermissions = await (
            from r in context.Roles
            join c in context.RoleClaims
            on r.Id equals c.RoleId
            where userRoles.Contains(r.Name!)
            select c.ClaimValue)
            .Distinct()
            .ToListAsync(cancellationToken);


        return (userRoles, rolePermissions!);
    }
    private string GenrateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    private async Task SendUrlActionPasswordToClick(ApplicationUser user, string code)
    {

        var pathToAction = httpContext.ExAccessFullPathAction
            (_urlHelper, "Auth", "ResetPassword",
            user.Email, code, StateAccess.sendTopassword);


        var message = $"To Confirm Your Password Click Link: <a href='{pathToAction}'>confirm password</a>";

        BackgroundJob.Enqueue(() => emailsService.SendEmail(user.Email, message));

        logger.LogWarning("your code is {code}", code);
        await Task.CompletedTask;
    }

    private async Task SendUrlActionToConfirmEmail(ApplicationUser user, string code)
    {
        // Get Url To Actions 
        var pathToAction = httpContext.ExAccessFullPathAction(_urlHelper, "Auth", "ConfirmEmail", user.Id, code, StateAccess.sendToemail);

        var message = $"To Confirm Email Click Link: <a href='{pathToAction}'>Link Of Confirmation</a>";
        var emailBody = new Dictionary<string, string>
        {
            {"{{name}}",user.Email },
            {"{{action_url}}",pathToAction }
        };
        var body = EmailBodyBuilder.GenerateEmailBody("EmailConfirmation", emailBody);

        BackgroundJob.Enqueue(() => emailsService.SendEmail(user.Email, body));

        // await emailsService.SendEmail(user.Email, body);
        await Task.CompletedTask;
    }
    private string AccessFullPathAction(HttpContext context, IUrlHelper urlHelper, string contollerName, string actionName, string Id, string code)
    {
        var httpContext = context!.Request;
        var pathToAction = $"{httpContext.Scheme}://{httpContext.Host}{urlHelper.Action(actionName, contollerName, new { UserId = Id, Code = code })}";
        return pathToAction;
    }
    private async Task<string?> GenerateCodeToConfirmEmail(ApplicationUser user)
    {
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        return code;
    }
    private async Task<string?> GenerateCodeToResetPassword(ApplicationUser user)
    {
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        return code;
    }


    private async Task<AuthResponse> GenerateTokenWithRefreshToken(ApplicationUser user)
    {
        var (userRoles, rolePermissions) = await GenerateUserRolesPermissions(user);

        var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, rolePermissions);

        var refreshToken = GenrateRefreshToken();
        var refreshTokenExpiryDate = DateTime.UtcNow.AddDays(_RefreshTokenExpirition);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpireOn = refreshTokenExpiryDate
        });

        await _userManager.UpdateAsync(user);

        var authResponse = new AuthResponse
        {
            Id = user.Id,
            Email = user.Email!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token,
            ExpireIn = expiresIn,
            RefreshToken = refreshToken,
            RefreshTokenExpirtion = refreshTokenExpiryDate
        };

        return authResponse;
    }




}