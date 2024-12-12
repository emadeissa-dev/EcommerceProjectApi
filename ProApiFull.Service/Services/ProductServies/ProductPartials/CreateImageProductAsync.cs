using ProApiFull.Domin.Entities.Models.Products;
using ProApiFull.Service.Contract.Products.Create;
using ProApiFull.Service.Contract.Products.Images;
using ProApiFull.Service.Localizations;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<List<CreateImageProductResponse>>> CreateImageProductAsync(CreateImageProductRequest request, CancellationToken cancellation = default!)
    {
        var getProduct = await imageProduct
            .Entity.GetTableNoTracking()
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.ProductId
            == request.ProductId, cancellationToken: cancellation);
        if (getProduct == null)
            return NotFound<List<CreateImageProductResponse>>
                (GetMessageLocalize(SharedKeys.NotFoundProduct));

        var getImages = await fileService.UploadManyAsync(request.Files, "ImagesProducts", cancellation);
        var mappImage = mapper.Map<List<ImageProduct>>(getImages);
        foreach (var image in mappImage)
            image.ProductId = request.ProductId;

        await imageProduct.Entity.AddRangeAsync(mappImage, cancellation);

        var response = mapper.Map<List<CreateImageProductResponse>>(mappImage);
        foreach (var productName in response)
            productName.ProductName = Localize.Localized(getProduct.Product!.NameAr, getProduct.Product!.NameEn);

        return Success(response);
    }
}
