using ProApiFull.Service.Contract.Roles;

namespace ProApiFull.Api.Controllers;

public class RolesController : AppControllerBase
{
    private readonly IRoleService roleService;

    public RolesController(IRoleService roleService)
    {
        this.roleService = roleService;
    }
    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromQuery] bool? includeDisabled, CancellationToken cancellationToken)
    {
        var roles = await roleService.GetAllAsync(includeDisabled, cancellationToken);
        return Ok(roles);
    }

    [HttpGet(nameof(GetById))]
    public async Task<IActionResult> GetById([FromQuery] string Id)
    {
        var role = await roleService.GetAsync(Id);
        return role.IsSuccess ? Ok(role.Value) : ToProblem(role);
    }

    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(RoleRequest request)
    {
        var role = await roleService.CreateAsync(request);
        return role.IsSuccess ? Ok(role.Value) : ToProblem(role);
    }

    [HttpPut(nameof(Update) + "/{Id}")]
    public async Task<IActionResult> Update([FromRoute] string Id, RoleRequest request)
    {
        var role = await roleService.UpdateAsync(Id, request);
        return role.IsSuccess ? Ok(role.Value) : ToProblem(role);
    }
    [HttpPut(nameof(ToggleStatus) + "/{Id}")]
    public async Task<IActionResult> ToggleStatus([FromRoute] string Id)
    {
        var role = await roleService.ToggleStatusAsync(Id);
        return role.IsSuccess ? Ok(role.Value) : ToProblem(role);
    }
}
