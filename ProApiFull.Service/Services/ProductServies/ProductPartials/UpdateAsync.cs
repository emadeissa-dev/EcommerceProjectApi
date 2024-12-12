using ProApiFull.Domin.Entities.Models.Products;
using ProApiFull.Service.Contract.Products.Update;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<UpdateProductResponse>> UpdateAsync(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var getProduct = await product.Entity.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (getProduct == null)
            return NotFound<UpdateProductResponse>
       (GetMessageLocalize(SharedKeys.NotFoundProduct));

        var productExist = await product.Entity.FirstOrDefaultAsync(x => x.Id != request.Id && (x.NameAr == request.NameAr || x.NameEn == request.NameEn), cancellationToken);
        if (productExist != null)
            return Duplicated<UpdateProductResponse>();

        var getImages = await fileService.UploadManyAsync(request.Images, "ImagesProducts", cancellationToken);


        if (request.Images != null)
        {
            var images = await imageProduct.Entity.AnyAsync(x => x.ProductId == request.Id && !x.IsUpdatedOrDeleted);
            if (images) await context.ImageProducts
                    .Where(x => x.ProductId == request.Id)
                    .ExecuteUpdateAsync(x => x.SetProperty(x =>
                    x.IsUpdatedOrDeleted, true));
        }

        var mappImage = mapper.Map<List<ImageProduct>>(getImages);

        getProduct.NameAr = request.NameAr;
        getProduct.NameEn = request.NameEn;
        getProduct.Price = request.Price;
        getProduct.DescrptionEn = request.DescrptionEn;
        getProduct.DescrptionAr = request.DescrptionAr;
        getProduct.CategoryId = request.CategoryId;
        getProduct.Images = mappImage;

        await product.Entity.UpdateAsync(getProduct, cancellationToken);

        var response = mapper.Map<UpdateProductResponse>(getProduct);

        response.Images = mapper.Map<List<UpdateImageResponse>?>(mappImage);

        return Success(response);
    }
}
