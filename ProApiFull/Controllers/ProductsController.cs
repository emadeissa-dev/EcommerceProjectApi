using ProApiFull.Service.Abstractions.Paginations;
using ProApiFull.Service.Contract.Products.Create;
using ProApiFull.Service.Contract.Products.Update;
using ProApiFull.Service.Services.CategoryServies;

namespace ProApiFull.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : AppControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productService.CreateAsync(request, cancellationToken);
        return product.IsSuccess ? Ok(product.Value) : ToProblem(product);
    }

    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update([FromForm] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productService.UpdateAsync(request, cancellationToken);
        return product.IsSuccess ? Ok(product.Value) : ToProblem(product);
    }
    [AllowAnonymous]
    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll([FromQuery] RequestFilters request, [FromQuery] bool? includeDeleted = false)
    {
        var product = await productService.GetAllAsync(request, includeDeleted);
        return product.IsSuccess ? Ok(product.Value) : ToProblem(product);
    }
    [AllowAnonymous]
    [HttpGet(nameof(GetById))]
    public async Task<IActionResult> GetById([FromQuery] int Id, [FromQuery] bool? includeDeleted = false)
    {
        var product = await productService.GetAsync(Id, includeDeleted);
        return product.IsSuccess ? Ok(product.Value) : ToProblem(product);
    }
    [AllowAnonymous]
    [HttpPost(nameof(ResetProducts))]
    public async Task<IActionResult> ResetProducts(CancellationToken cancellationToken)
    {
        var reset = await productService.ResetIdTableAsync(cancellationToken);
        return reset.IsSuccess ? Ok(reset.Value) : ToProblem(reset);
    }
    [HttpPost(nameof(CreateImageProduct))]
    public async Task<IActionResult> CreateImageProduct([FromForm] CreateImageProductRequest request, CancellationToken cancellationToken)
    {
        var imageProduct = await productService.CreateImageProductAsync(request, cancellationToken);
        return imageProduct.IsSuccess ? Ok(imageProduct.Value) : ToProblem(imageProduct);
    }
    [HttpPut(nameof(ToggleStatedDeleted))]
    public async Task<IActionResult> ToggleStatedDeleted(int Id, CancellationToken cancellationToken)
    {
        var imageProduct = await productService.ToggleStatusImageAsync(Id, cancellationToken);
        return imageProduct.IsSuccess ? Ok(imageProduct) : ToProblem(imageProduct);
    }
    [AllowAnonymous]
    [HttpGet("download/{ImageId}")]
    public async Task<IActionResult> download(int ImageId, CancellationToken cancellationToken)
    {
        var file = await productService.DownloadAsync(ImageId, cancellationToken);

        return file.IsSuccess ? File(file.Value.FileContent, file.Value.ContentType, file.Value.FileName)
           : ToProblem(file);
    }
    [HttpDelete("delete-actual/{Id}")]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
    {
        var deleted = await productService.DeletedActualAsync(Id, cancellationToken);

        return deleted.IsSuccess ? Ok(deleted) : ToProblem(deleted);
    }
}
