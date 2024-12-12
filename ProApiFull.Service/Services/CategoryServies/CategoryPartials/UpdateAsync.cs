namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<UpdateCategoryRequest>> UpdateAsync(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _category.Entity.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (category == null) return NotFound<UpdateCategoryRequest>();

        var checkExistAr = await _category.Entity.AnyAsync(x => x.NameAr == request.NameAr && x.Id != request.Id);
        if (checkExistAr)
            return Duplicated<UpdateCategoryRequest>(stringLocalizer[SharedKeys.DuplicatedAr].Value);
        var checkExistEn = await _category.Entity.AnyAsync(x => x.NameEn == request.NameEn && x.Id != request.Id);
        if (checkExistEn)
            return Duplicated<UpdateCategoryRequest>(stringLocalizer[SharedKeys.DuplicatedEn].Value);

        category.Id = request.Id;
        category.NameAr = request.NameAr;
        category.NameEn = request.NameEn;

        await _category.Entity.SaveChangesAsync(cancellationToken);
        return Success(request);
    }
}
