namespace ProApiFull.Service.Contract;
public class ChangePasswordRequestValidators : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidators()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty();

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase")
            .NotEqual(x => x.CurrentPassword)
            .WithMessage("password must be diffrent from the currend passoerd");
    }
}

