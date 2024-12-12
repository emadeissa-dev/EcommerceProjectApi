namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<GetCategoryResponse>> DeletedActualAsync(int Id, CancellationToken cancellationToken = default!, bool? includeDeleted = false)
    {
        var category = await _category.Entity.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        if (category == null)
            return NotFound<GetCategoryResponse>(
               MessageLocalize(SharedKeys.NotFoundCategory));

        // To Do Relations

        await _category.Entity.DeleteAsync(category, cancellationToken);

        return Success(mapper.Map<GetCategoryResponse>(category));
    }
}
