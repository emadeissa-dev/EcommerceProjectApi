using ProApiFull.Service.Abstractions.Paginations;

namespace ProApiFull.Service.Services.CategoryServies;
public interface ICategoryService
{
    public bool IsExist(int Id);
    Task<Result<GetCategoryResponse>> GetAsync(int Id, CancellationToken cancellationToken = default!, bool? includeDeleted = false);
    Task<Result<UpdateCategoryRequest>> UpdateAsync(UpdateCategoryRequest request, CancellationToken cancellationToken);
    Task<Result<PaginatedList<GetCategoryResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default!, bool? includeDeleted = false);
    Task<Result<CreateCategoryRequest>> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<Result<GetCategoryResponse>> AssignAsDeletedAsync(int Id, CancellationToken cancellationToken = default!, bool? includeDeleted = false);
    Task<Result<GetCategoryResponse>> EnableCategoryAsync(int Id, CancellationToken cancellationToken = default!);
    Task<Result<GetCategoryResponse>> DeletedActualAsync(int Id, CancellationToken cancellationToken = default!, bool? includeDeleted = false);
    Task<Result<string>> ResetIdTableAsync(CancellationToken cancellationToken = default);
}
