using ProApiFull.Service.Abstractions.Paginations;
using ProApiFull.Service.Contract.Category;
using ProApiFull.Service.IdentityServices.AuthenticationService.Filters;
using ProApiFull.Service.Services.CategoryServies;
using ProApiFull.Shared.Consts;

namespace ProApiFull.Api.Controllers;
[Route("api/[controller]")]
[ApiController]

public class CategoriesController : AppControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }
    [HttpGet("IsEnglish/{value}")]
    public async Task<IActionResult> IsEnglish([FromRoute] string value)
    {
        var newValue = new string(value);

        return value.IsEnglish() ? Ok(newValue.ExTitleCase()) : BadRequest("not english");

    }
    [HttpGet("ExGetEnglishLetters/{value}")]
    public async Task<IActionResult> ExGetEnglishLetters([FromRoute] string value)
    {
        var newValue = value.ExGetEnglishLetters();

        return newValue != null ? Ok(newValue.ExTitleCase()) : BadRequest("not english");

    }
    [HasPermission(Permissions.GetCategories)]
    [HttpGet("get-list")]
    public async Task<IActionResult> GetAll([FromQuery] RequestFilters request, CancellationToken cancellationToken, bool? includeDeleted = false)
    {
        var categories = await categoryService.GetAllAsync(request, cancellationToken, includeDeleted);

        return categories.IsSuccess ? Ok(categories.Value)
            : ToProblem(categories);
    }
    [HasPermission(Permissions.GetCategories)]
    [HttpGet("get-row/{Id}")]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken, bool? includeDeleted = false)
    {
        var category = await categoryService.GetAsync(Id, cancellationToken, includeDeleted);

        return category.IsSuccess ? Ok(category.Value)
            : ToProblem(category);
    }
    [HasPermission(Permissions.AddCategories)]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var createCategory = await categoryService.CreateAsync(request, cancellationToken);

        return createCategory.IsSuccess ? Ok(createCategory.Value)
            : ToProblem(createCategory);
    }
    [HasPermission(Permissions.UpdateCategories)]
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var updateCategory = await categoryService.UpdateAsync(request, cancellationToken);

        return updateCategory.IsSuccess ? Ok(updateCategory.Value)
            : ToProblem(updateCategory);
    }
    [HasPermission(Permissions.UpdateCategories)]
    [HttpPut("enable/{Id}")]
    public async Task<IActionResult> EnableAsync(int Id, CancellationToken cancellationToken)
    {
        var updateCategory = await categoryService.EnableCategoryAsync(Id, cancellationToken);

        return updateCategory.IsSuccess ? Ok(updateCategory.Value)
            : ToProblem(updateCategory);
    }

    [HasPermission(Permissions.DeleteCategories)]
    [HttpDelete("assign-delete/{Id}")]
    public async Task<IActionResult> AssignAsDeleted(int Id, CancellationToken cancellationToken)
    {
        var category = await categoryService.AssignAsDeletedAsync(Id, cancellationToken, true);

        return category.IsSuccess ? Ok(category.Value)
            : ToProblem(category);
    }
    [HasPermission(Permissions.DeleteCategories)]
    [HttpDelete("delete/{Id}")]
    public async Task<IActionResult> DeletedActual(int Id, CancellationToken cancellationToken)
    {
        var category = await categoryService.DeletedActualAsync(Id, cancellationToken, true);

        return category.IsSuccess ? Ok(category.Value)
            : ToProblem(category);
    }
    [HasPermission(Permissions.AddCategories)]
    [HttpPost("reset")]
    public async Task<IActionResult> ResetIdTable(CancellationToken cancellationToken)
    {
        var category = await categoryService.ResetIdTableAsync(cancellationToken);

        return category.IsSuccess ? Ok(category.Value)
            : ToProblem(category);
    }

}
