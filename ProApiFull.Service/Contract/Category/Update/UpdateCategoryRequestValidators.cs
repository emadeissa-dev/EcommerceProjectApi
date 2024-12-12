namespace ProApiFull.Service.Contract.Category;
public class UpdateCategoryRequestValidators : AbstractValidator<UpdateCategoryRequest>
{
    private readonly IStringLocalizer<SharedResources> stringLocalizer;

    public UpdateCategoryRequestValidators(IStringLocalizer<SharedResources> stringLocalizer)
    {

        this.stringLocalizer = stringLocalizer;
        UpdateCategoryRequesyValidatorsP();

    }
    private void UpdateCategoryRequesyValidatorsP()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
             .NotNull()
             .WithMessage(MessageLocalize(SharedKeys.RequiredId));

        RuleFor(x => x.NameAr)
            .NotEmpty()
             .NotNull()
             .WithMessage(MessageLocalize(SharedKeys.RequiredNameAr))
              .Length(1, 149)
             .WithMessage(MessageLocalize(SharedKeys.ValidateMinMaxCategory));


        RuleFor(x => x.NameEn)
            .NotEmpty()
             .NotNull()
             .WithMessage(stringLocalizer[SharedKeys.RequiredNameEn].Value)
            .Length(1, 149)
             .WithMessage(MessageLocalize(SharedKeys.ValidateMinMaxCategory));
    }

    public string MessageLocalize(string key) =>
       stringLocalizer[key].Value.ExTitleCase();
}
