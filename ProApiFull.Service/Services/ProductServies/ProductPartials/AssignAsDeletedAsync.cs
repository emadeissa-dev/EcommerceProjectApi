namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result> AssignAsDeletedAsync(int Id, CancellationToken cancellationToken = default!)
    {
        var getProduct = await product.Entity.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        if (getProduct == null)
            return NotFound(GetMessageLocalize(SharedKeys.NotFoundProduct));

        await context.Products.Where(x => x.Id == getProduct!.Id)
            .ExecuteUpdateAsync(x =>
            x.SetProperty(x => x.IsDeleted, true));

        return Success(GetMessageLocalize(SharedKeys.DeletedSuccess));
    }
}


