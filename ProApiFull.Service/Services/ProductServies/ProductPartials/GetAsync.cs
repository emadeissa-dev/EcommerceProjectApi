using ProApiFull.Service.Contract.Products.GetAll;

namespace ProApiFull.Service.Services;
public partial class ProductService
{
    public async Task<Result<GetProductByIdResponse>> GetAsync(int Id, bool? includeDeleted = false)
    {
        var getProduct = product.Entity
            .IncludeQueryable(critria: x => x.Id == Id
           , x => x.Images!, s => s.Category).FirstOrDefault();

        if (getProduct == null)
            return NotFound<GetProductByIdResponse>
                 (GetMessageLocalize(SharedKeys.NotFoundProduct));


        if (includeDeleted == false)
            getProduct.Images = getProduct.Images.Where(x => !x.IsUpdatedOrDeleted)!.ToList();


        var mappProduct = mapper.Map<GetProductByIdResponse>(getProduct);
        mappProduct.CountFiles = getProduct.Images!.Count();
        return Success(mappProduct!);
    }
}
