namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result> ToggleStatusImageAsync(int imageId, CancellationToken cancellation = default!)
    {
        var getImage = await imageProduct.Entity.FirstOrDefaultAsync(x => x.Id == imageId, cancellation);
        if (getImage == null)
            return NotFound(
                GetMessageLocalize(SharedKeys.NotFoundProduct));
        getImage.IsUpdatedOrDeleted = !getImage.IsUpdatedOrDeleted;
        await imageProduct.Entity.UpdateAsync(getImage!, cancellation);
        return getImage.IsUpdatedOrDeleted == true
            ? Success(GetMessageLocalize(SharedKeys.AssignDeletedImageProduct))
            : Success(GetMessageLocalize(SharedKeys.AssignFromDeletedImage));

    }
}
