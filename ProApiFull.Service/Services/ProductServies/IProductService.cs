using ProApiFull.Service.Abstractions.Paginations;
using ProApiFull.Service.Contract.Products.Create;
using ProApiFull.Service.Contract.Products.GetAll;
using ProApiFull.Service.Contract.Products.Images;
using ProApiFull.Service.Contract.Products.Update;

namespace ProApiFull.Service.Services.CategoryServies;
public interface IProductService
{
    Task<Result<DownloadImageResponse>> DownloadAsync(int imageId, CancellationToken cancellationToken = default!);
    Task<Result> ToggleStatusImageAsync(int imageId, CancellationToken cancellation = default!);
    Task<Result<List<CreateImageProductResponse>>> CreateImageProductAsync(CreateImageProductRequest request, CancellationToken cancellation = default!);
    Task<Result<string>> ResetIdTableAsync(CancellationToken cancellationToken = default);
    Task<Result<GetProductByIdResponse>> GetAsync(int Id, bool? includeDeleted = false);
    Task<Result> DeletedActualAsync(int Id, CancellationToken cancellationToken = default!);
    Task<Result> EnableAsync(int Id, CancellationToken cancellationToken = default!); Task<Result<UpdateProductResponse>> UpdateAsync(UpdateProductRequest request, CancellationToken cancellationToken);    ////Task<Result<List<GetCategoryResponse>>> GetAllAsync(CancellationToken cancellationToken = default!, bool? includeDeleted = false);
    Task<Result<CreateProductResponse>> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken);
    Task<Result> AssignAsDeletedAsync(int Id, CancellationToken cancellationToken = default!);

    Task<Result<PaginatedList<GetProductListResponse>>> GetAllAsync(RequestFilters filters, bool? includeDeleted = false);
}
