using ProApiFull.Service.Contract.Products.Images;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<DownloadImageResponse>> DownloadAsync(int imageId, CancellationToken cancellationToken = default!)
    {
        var getImage = await imageProduct.Entity.FirstOrDefaultAsync(x => x.Id == imageId && !x.IsUpdatedOrDeleted);
        if (getImage == null)
            return NotFound<DownloadImageResponse>(GetMessageLocalize(SharedKeys.NotFoundImage));
        var (fileContent, contentType, fileName)
            = await fileService.DownloadAsync(getImage.FileName,
            getImage.ContentType, "ImagesProducts");

        var response = new DownloadImageResponse
            (fileContent, fileName, contentType);

        return Success(response);
    }
}

