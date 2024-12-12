namespace ProApiFull.Service.Mapping.ApplicationUserMapping;
public class MappingApplicationUser : Profile
{
    public MappingApplicationUser()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(src => src.UserName, dest => dest.MapFrom(x => x.Email));


    }
}