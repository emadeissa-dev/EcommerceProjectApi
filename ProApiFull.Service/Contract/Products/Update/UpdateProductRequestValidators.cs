using ProApiFull.Service.Contract.Products.Update;
using ProApiFull.Service.Services.CategoryServies;

namespace ProApiFull.Service.Contract.Products.Create;
public class UpdateProductRequestValidators : AbstractValidator<UpdateProductRequest>
{
    private readonly IStringLocalizer<SharedResources> stringLocalizer;
    private readonly ICategoryService categoryService;

    public UpdateProductRequestValidators(
        IStringLocalizer<SharedResources> stringLocalizer,
        ICategoryService categoryService)
    {

        this.stringLocalizer = stringLocalizer;
        this.categoryService = categoryService;
        CreateCategoryRequesyValidatorsP();

    }
    private void CreateCategoryRequesyValidatorsP()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.CategoryId)
             .NotEmpty()
                .NotNull();


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


