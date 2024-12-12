namespace ProApiFull.Service.Contract;
public class LoginRequestValidators : AbstractValidator<LoginRequest>
{
    public LoginRequestValidators()
    {
        CreateValidationCategory();
    }
    private void CreateValidationCategory()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("{PropertyName} Is Invalid")
            .NotEmpty()
            .WithMessage("{PropertyName} Is Required 00");

        RuleFor(x => x.Password)
                .NotEmpty()
                 .WithMessage("{PropertyName} Is Required 00");
    }
}
