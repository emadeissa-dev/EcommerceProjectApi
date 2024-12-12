using ProApiFull.Service.Contract.Products.Images;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result> EnableAsync(int Id, CancellationToken cancellationToken = default!)
    {
        var getProduct = await product.Entity.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted, cancellationToken);
        if (getProduct == null)
            return NotFound<List<CreateImageProductResponse>>
            (GetMessageLocalize(SharedKeys.NotFoundProduct));

        await context.Products.Where(x => x.Id == Id)
            .ExecuteUpdateAsync(x =>
            x.SetProperty(x => x.IsDeleted, false), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Success(GetMessageLocalize(SharedKeys.EnableProduct));

    }
}
