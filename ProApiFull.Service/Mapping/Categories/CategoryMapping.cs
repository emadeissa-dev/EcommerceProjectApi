namespace ProApiFull.Service.Mapping.Categories;
public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(src => src.NameAr, dest => dest.MapFrom(x => x.NameAr))
            .ForMember(src => src.NameEn, dest => dest.MapFrom(x => x.NameEn));

        CreateMap<UpdateCategoryRequest, Category>()
    .ForMember(src => src.NameAr, dest => dest.MapFrom(x => x.NameAr))
    .ForMember(src => src.NameEn, dest => dest.MapFrom(x => x.NameEn));

        CreateMap<Category, GetCategoryResponse>()
         .ForMember(src => src.Name, dest => dest.MapFrom(x => x.GetLocalized(x.NameAr, x.NameEn)))
         .ForMember(src => src.UpdatedBy, dest => dest.MapFrom(x => x.UpdatedBy!.UserName))
         .ForMember(src => src.CreatedBy, dest => dest.MapFrom(x => x.CreatedBy!.UserName));



    }
}
