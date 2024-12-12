using ProApiFull.Service.Contract.Products.Create;

namespace ProApiFull.Service.Mapping.ProductMapping;
public partial class ProductMapProfile
{
    private void MapProductRequestAndProduct()
    {
        CreateMap<CreateProductRequest, Product>()
        .ForMember(x => x.Images, x => x.Ignore()).ReverseMap();
    }
}
