using ProApiFull.Service.Contract.Products.Images;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result> DeletedActualAsync(int Id, CancellationToken cancellationToken = default!)
    {
        var getProduct = await product.Entity.IncludeQueryableTracking(x => x.Id == Id, x => x.Images).FirstOrDefaultAsync();
        if (getProduct == null)
            return NotFound<List<CreateImageProductResponse>>
       (GetMessageLocalize(SharedKeys.NotFoundProduct));

        using var transaction = await product.Entity.BeginTransactionAsync(cancellationToken);
        try
        {
            var getImages = await imageProduct.Entity.ToListAsync(x => x.ProductId == Id);
            var imageForDelete = getImages.Select(x => x.FileName).ToList();
            foreach (var image in getImages)
                await imageProduct.Entity.DeleteAsync(image);

            await product.Entity.DeleteAsync(getProduct!, cancellationToken);

            await fileService.DeleteFile(imageForDelete, "ImagesProducts");
            await product.Entity.CommitAsync();
            return Success(GetMessageLocalize(SharedKeys.DeletedSuccess));
        }
        catch (Exception)
        {
            await product.Entity.RollBackAsync();
            return BadRequest();
        }
    }
}
