namespace ProApiFull.Service.IdentityServices;
public partial class UserService : ResponseError, IUserService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly ApplicationDbContext context;
    private readonly IRoleService roleService;


    public UserService(
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context
,
        IRoleService roleService)
    {
        this.userManager = userManager;
        this.context = context;
        this.roleService = roleService;

    }











}
