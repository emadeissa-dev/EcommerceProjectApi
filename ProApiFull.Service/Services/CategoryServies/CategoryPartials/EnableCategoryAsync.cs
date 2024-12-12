namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<GetCategoryResponse>> EnableCategoryAsync(int Id, CancellationToken cancellationToken = default!)
    {
        var category = await _category.Entity.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted, cancellationToken);
        if (category == null)
            return NotFound<GetCategoryResponse>(
       MessageLocalize(SharedKeys.NotFoundCategory));

        await context.Categories.Where(x => x.Id == Id)
            .ExecuteUpdateAsync(x =>
            x.SetProperty(x => x.IsDeleted, false), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Success(mapper.Map<GetCategoryResponse>(category));
    }
}
