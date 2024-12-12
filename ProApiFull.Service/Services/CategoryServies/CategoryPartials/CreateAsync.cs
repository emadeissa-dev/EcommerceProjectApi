namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<CreateCategoryRequest>> CreateAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var deletedCategory = await _category.Entity.FirstOrDefaultAsync(x => x.NameAr == request.NameAr
            && x.NameEn == request.NameEn && x.IsDeleted);

        if (deletedCategory != null)
        {
            await context.Categories
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, false));
            await context.SaveChangesAsync();
            return Success(request);
        }

        else
            if (await _category.Entity
            .AnyAsync(x => x.NameAr == request.NameAr
            || x.NameEn == request.NameEn && !x.IsDeleted))
            return Duplicated<CreateCategoryRequest>
            (MessageLocalize(SharedKeys.DuplicateName));
        var mapCategory = mapper.Map<Category>(request);

        await _category.Entity.AddAsync(mapCategory);

        return Success(request);
    }
}
