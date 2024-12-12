using ProApiFull.Infrastructure.UnitOfWork;
using ProApiFull.Service.Services.CategoryServies;

namespace ProApiFull.Service.Services;
public partial class CategoryService : ResponseError, ICategoryService
{
    private readonly ApplicationDbContext context;
    private readonly IStringLocalizer<SharedResources> stringLocalizer;
    private readonly IMapper mapper;
    private readonly IDistributedMemoryServives distributedMemoryServives;
    private readonly IUnitOfWork<Category> _category;

    public CategoryService(
        ApplicationDbContext context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        IDistributedMemoryServives distributedMemoryServives,
        IUnitOfWork<Category> category
        )
    {
        this.context = context;
        this.stringLocalizer = stringLocalizer;
        this.mapper = mapper;
        this.distributedMemoryServives = distributedMemoryServives;
        _category = category;
    }
    public string MessageLocalize(string key) =>
     stringLocalizer[key].Value.ExTitleCase();
}
