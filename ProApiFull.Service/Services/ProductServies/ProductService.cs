using HandlingFiles.Services;
using ProApiFull.Domin.Entities.Models.Products;
using ProApiFull.Infrastructure.UnitOfWork;
using ProApiFull.Service.Services.CategoryServies;

namespace ProApiFull.Service.Services;
public partial class ProductService : ResponseError, IProductService
{
    private readonly IUnitOfWork<Product> product;
    private readonly IStringLocalizer<SharedResources> stringLocalizer;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    private readonly IUnitOfWork<ImageProduct> imageProduct;
    private readonly ApplicationDbContext context;

    public ProductService(
         IUnitOfWork<Product> product,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        IFileService fileService,
         IUnitOfWork<ImageProduct> imageProduct,
         ApplicationDbContext context


        )
    {

        this.product = product;

        this.mapper = mapper;
        this.fileService = fileService;
        this.imageProduct = imageProduct;
        this.context = context;
        this.imageProduct = imageProduct;
        this.stringLocalizer = stringLocalizer;
    }

    public string GetMessageLocalize(string key) =>
         stringLocalizer[key].Value.ExTitleCase();

}
