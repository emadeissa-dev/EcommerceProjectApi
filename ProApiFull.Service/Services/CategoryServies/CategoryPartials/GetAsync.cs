namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<GetCategoryResponse>> GetAsync(int Id, CancellationToken cancellationToken = default!, bool? includeDeleted = false)
    {
        var getCategory = await _category.Entity.AnyAsync(x => x.Id == Id);
        if (!getCategory)
            return NotFound<GetCategoryResponse>(MessageLocalize(SharedKeys.NotFoundCategory));


        var categories = _category.Entity
            .IncludeQueryable((x => x.Id == Id && (!x.IsDeleted || (includeDeleted.Value && includeDeleted.HasValue)))
            , x => x.CreatedBy, x => x.UpdatedBy).Select(category => new GetCategoryResponse
            {
                Id = category.Id,
                Name = category.GetLocalized(category.NameAr, category.NameEn),
                CreatedBy = category.CreatedBy.UserName,
                UpdatedBy = category.UpdatedBy.UserName,
                CreatedOn = category.CreatedOn,
                UpdatedOn = category.UpdatedOn

            }).FirstOrDefault();

        #region MyRegion
        //var categories = await context.Categories
        //    .Include(x => x.UpdatedBy).Include(x => x.CreatedBy)
        //    .Where((x => x.Id == Id && (!x.IsDeleted || (includeDeleted.Value && includeDeleted.HasValue))))
        //    .FirstOrDefaultAsync(cancellationToken);
        #endregion

        var mappCategories = mapper.Map<GetCategoryResponse>(categories);
        return Success(mappCategories);
    }
}
