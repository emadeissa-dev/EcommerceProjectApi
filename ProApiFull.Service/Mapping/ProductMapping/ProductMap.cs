using ProApiFull.Domin.Entities.Models.Products;
using ProApiFull.Domin.PublicEntities;
using ProApiFull.Service.Contract.Products;
using ProApiFull.Service.Contract.Products.Create;
using ProApiFull.Service.Contract.Products.GetAll;
using ProApiFull.Service.Contract.Products.Images;
using ProApiFull.Service.Contract.Products.Update;

namespace ProApiFull.Service.Mapping.ProductMapping;
public partial class ProductMapProfile : Profile
{

    public ProductMapProfile()
    {
        //Create
        MapProductRequestAndProduct();

        CreateMap<UploadFile, ImageProduct>();

        CreateMap<CreateProductRequest, CreateProductResponse>()
        .ForMember(x => x.Images, x => x.Ignore()).ReverseMap();


        CreateMap<ImageProduct, ImageResponse>().ReverseMap(); ;
        CreateMap<UploadFile, ImageResponse>(); ;


        //Update
        CreateMap<UpdateProductRequest, Product>()
            .ForMember(x => x.Images, x => x.Ignore()).ReverseMap();


        CreateMap<Product, UpdateProductResponse>()
        .ForMember(x => x.Images, x => x.Ignore()).ReverseMap();

        CreateMap<ImageProduct, UpdateImageResponse>();

        //getListProducts
        CreateMap<Product, GetProductListResponse>()
            .ForMember(x => x.Name, x => x.MapFrom(x => x.GetLocalized(x.NameAr, x.NameEn)))
            .ForMember(x => x.CountImages, x => x.MapFrom(x => x.Images!.Where(x => !x.IsUpdatedOrDeleted).Count()))
            .ForMember(x => x.CategoryName, x => x.MapFrom(x => x.GetLocalized(x.Category.NameAr, x.Category.NameEn)))
            .ForMember(x => x.Descrption, x => x.MapFrom(x => x.GetLocalized(x.DescrptionAr, x.DescrptionEn)))
            .ForMember(x => x.Images, x => x.MapFrom(x =>
            x.Images.Where(x => !x.IsUpdatedOrDeleted).Select(x => new ImageResponse
            {
                ContentType = x.ContentType,
                FileExetension = x.FileExetension,
                FileName = x.FileName,
            })));


        CreateMap<Product, GetProductByIdResponse>()
            .ForMember(x => x.Name, x => x.MapFrom(x => x.GetLocalized(x.NameAr, x.NameEn)))
            .ForMember(x => x.CategoryName, x => x.MapFrom(x => x.GetLocalized(x.Category.NameAr, x.Category.NameEn)))
            .ForMember(x => x.Descrption, x => x.MapFrom(x => x.GetLocalized(x.DescrptionAr, x.DescrptionEn)))
            .ForMember(x => x.Images, x => x.MapFrom(x =>
            x.Images.Select(x => new ImageResponse
            {
                ContentType = x.ContentType,
                FileExetension = x.FileExetension,
                FileName = x.FileName,
            })));

        CreateMap<ImageProduct, CreateImageProductResponse>()
            .ForMember(x => x.ProductName, x => x.Ignore());




    }


}