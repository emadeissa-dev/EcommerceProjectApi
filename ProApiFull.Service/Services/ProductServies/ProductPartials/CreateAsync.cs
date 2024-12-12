using ProApiFull.Domin.Entities.Models.Products;
using ProApiFull.Service.Contract.Products;
using ProApiFull.Service.Contract.Products.Create;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<CreateProductResponse>> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var deletedproduct = await product.Entity.GetTableNoTracking()
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.NameAr == request.NameAr
        && x.NameEn == request.NameEn && x.IsDeleted);

        if (deletedproduct != null)
        {
            var uploadImages = await fileService.UploadManyAsync(request.Images, "ImagesProducts", cancellationToken);
            var mappToImage = mapper.Map<List<ImageResponse>>(uploadImages);
            var mapTpResponse = mapper.Map<CreateProductResponse>(request);
            mapTpResponse.Images = mappToImage;

            var mapTpImageResponse = mapper.Map<List<ImageProduct>>(mapTpResponse.Images);
            foreach (var image in mapTpImageResponse)

                image.ProductId = deletedproduct.Id;

            deletedproduct.Images.AddRange(mapTpImageResponse);
            deletedproduct.IsDeleted = false;

            await imageProduct.Entity.AddRangeAsync(mapTpImageResponse, cancellationToken);
            await product.Entity.UpdateAsync(deletedproduct, cancellationToken);

            return Success(mapTpResponse);
        }
        else
        if (await product.Entity
        .AnyAsync(x => x.NameAr == request.NameAr
        || x.NameEn == request.NameEn && !x.IsDeleted))
            return Duplicated<CreateProductResponse>
            (GetMessageLocalize(SharedKeys.DuplicatedProductName));


        var getImages = await fileService.UploadManyAsync(request.Images, "ImagesProducts", cancellationToken);

        var mappImage = mapper.Map<List<ImageProduct>>(getImages);

        var mappProduct = mapper.Map<Product>(request);
        mappProduct.Images = mappImage;

        await product.Entity.AddAsync(mappProduct, cancellationToken);
        var response = mapper.Map<CreateProductResponse>(request);

        response.Images = mapper.Map<List<ImageResponse>?>(mappImage);

        return Success(response);

    }
}
