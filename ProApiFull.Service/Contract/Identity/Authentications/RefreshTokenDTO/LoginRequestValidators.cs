namespace ProApiFull.Service.Contract;
public class RefreshTokenRequestValidators : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidators()
    {
        CreateValidationCategory();
    }
    private void CreateValidationCategory()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("{PropertyName} Is Required 00");

        RuleFor(x => x.RefreshToken)
                .NotEmpty()
                 .WithMessage("{PropertyName} Is Required 00");
    }
}
