using ProApiFull.Service.Abstractions.Paginations;
using System.Linq.Dynamic.Core;

namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<PaginatedList<GetCategoryResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken = default!, bool? includeDeleted = false)
    {

        //var categories = _category.Entity
        //    .GetWithInclude((x => !x.IsDeleted || includeDeleted == true)
        //    , x => x.CreatedBy, x => x.UpdatedBy).Select(category => new GetCategoryResponse
        //    {
        //        Id = category.Id,
        //        Name = category.GetLocalized(category.NameAr, category.NameEn),
        //        CreatedBy = category.CreatedBy.UserName,
        //        UpdatedBy = category.UpdatedBy.UserName,
        //        CreatedOn = category.CreatedOn,
        //        UpdatedOn = category.UpdatedOn

        //    }).ToList();



        var categories = context.Categories
             .Include(x => x.UpdatedBy).Include(x => x.CreatedBy)
             .Where(x => !x.IsDeleted || (includeDeleted == true))
             .Select(category => new GetCategoryResponse
             {
                 Id = category.Id,
                 Name = category.GetLocalized(category.NameAr, category.NameEn),
                 CreatedBy = category.CreatedBy.UserName,
                 UpdatedBy = category.UpdatedBy.UserName,
                 CreatedOn = category.CreatedOn,
                 UpdatedOn = category.UpdatedOn

             });

        var all = await PaginatedList<GetCategoryResponse>.CreateAsync(categories, filters.PageNumber, filters.PageSize);


        return Success(all);
    }
}
