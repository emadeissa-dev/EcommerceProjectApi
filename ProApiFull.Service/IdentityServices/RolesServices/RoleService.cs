namespace ProApiFull.Service.IdentityServices;
public partial class RoleService : ResponseError, IRoleService
{
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly ApplicationDbContext context;


    public RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
    {
        this.roleManager = roleManager;
        this.context = context;
    }
}
