using ProApiFull.Service.Services.CategoryServies;

namespace ProApiFull.Service.Contract.Products.Create;
public class CreateProductRequestValidators : AbstractValidator<CreateProductRequest>
{
    private readonly IStringLocalizer<SharedResources> stringLocalizer;
    private readonly ICategoryService categoryService;

    public CreateProductRequestValidators(
        IStringLocalizer<SharedResources> stringLocalizer,
        ICategoryService categoryService)
    {

        this.stringLocalizer = stringLocalizer;
        this.categoryService = categoryService;
        CreateCategoryRequesyValidatorsP();

    }
    private void CreateCategoryRequesyValidatorsP()
    {
        RuleFor(x => x.CategoryId)
            .NotNull()
            .NotEmpty();


        RuleFor(x => x.Price)
            .Must(x => x > 0)
            .WithMessage("price must be bigger than 0");


        RuleForEach(x => x.Images)
            .SetValidator(new FileSizeValitor())
            .SetValidator(new BlockSignatureValidators());

        RuleFor(x => x.CategoryId)
            .Must(x => categoryService.IsExist(x))
            .WithMessage("category id is not exist")
            .When(x => x.CategoryId != 0);
    }


}

