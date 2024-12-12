namespace ProApiFull.Service.Contract.Category;
public class CreateCategoryRequestValidators : AbstractValidator<CreateCategoryRequest>
{
    private readonly IStringLocalizer<SharedResources> stringLocalizer;

    public CreateCategoryRequestValidators(IStringLocalizer<SharedResources> stringLocalizer)
    {

        this.stringLocalizer = stringLocalizer;
        CreateCategoryRequesyValidatorsP();

    }
    private void CreateCategoryRequesyValidatorsP()
    {
        RuleFor(x => x.NameAr)
            .NotEmpty()
             .NotNull()
             .WithMessage(MessageLocalize(SharedKeys.RequiredNameAr))
            .Length(1, 149)
             .WithMessage(MessageLocalize(SharedKeys.ValidateMinMaxCategory));

        RuleFor(x => x.NameEn)
            .NotEmpty()
             .NotNull()
             .WithMessage(MessageLocalize(SharedKeys.RequiredNameEn))
             .Length(1, 149)
             .WithMessage(MessageLocalize(SharedKeys.ValidateMinMaxCategory));
    }
    public string MessageLocalize(string key) =>
         stringLocalizer[key].Value.ExTitleCase();
}
