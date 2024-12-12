namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<string>> ResetIdTableAsync(CancellationToken cancellationToken = default)
    {
        if (await product.Entity.AnyAsync(cancellationToken: cancellationToken))
            return BadRequest<string>
                (GetMessageLocalize(SharedKeys.FailedResetProduct));

        await product.Entity.ResetTable(nameof(context.Products), cancellationToken);


        return BadRequest<string>
                (GetMessageLocalize(SharedKeys.ResetproductSuccess)); ;
    }
}
