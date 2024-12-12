using ProApiFull.Service.Abstractions.Paginations;
using ProApiFull.Service.Contract.Products.GetAll;
using ProApiFull.Service.Localizations;
using System.Linq.Dynamic.Core;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<PaginatedList<GetProductListResponse>>> GetAllAsync(RequestFilters request, bool? includeDeleted = false)
    {
        var getProducts = product.Entity.IncludeQueryable(includes: x => x.Images);
        if (!string.IsNullOrEmpty(request.Search))
            if (Localize.Localized() == "ar")
                getProducts = getProducts.Where(x => x.NameAr.Contains(request.Search));
            else getProducts = getProducts.Where(x => x.NameEn.Contains(request.Search));
        if (!string.IsNullOrEmpty(request.SortColmin))
            getProducts = getProducts.OrderBy($"{request.SortColmin} {request.SortDirection}");
        var mappProducts = mapper.ProjectTo<GetProductListResponse>(getProducts);
        var paginatedList = await PaginatedList<GetProductListResponse>.CreateAsync(mappProducts, request.PageNumber, request.PageSize);
        return Success(paginatedList);
    }
}
