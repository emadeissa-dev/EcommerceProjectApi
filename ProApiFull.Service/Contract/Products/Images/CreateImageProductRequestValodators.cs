namespace ProApiFull.Service.Contract.Products.Create.Images;
public class CreateImageProductRequestValodators : AbstractValidator<CreateImageProductRequest>
{
    public CreateImageProductRequestValodators()
    {
        RuleFor(x => x.ProductId)
            .NotNull()
            .NotEmpty()
            .WithMessage("product id is required ");

        RuleFor(x => x.Files)
            .NotNull()
            .NotEmpty()
            .WithMessage("files is required");

        RuleForEach(x => x.Files)
        .SetValidator(new FileSizeValitor())
        .SetValidator(new BlockSignatureValidators());
    }

}
