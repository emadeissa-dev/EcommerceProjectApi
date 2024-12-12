namespace ProApiFull.Service.Contract;
public class ResetPasswordRequestValidators : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidators()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Code)
          .NotNull()
          .NotEmpty();


        RuleFor(x => x.NewPassword)
          .NotEmpty()
          .Matches(RegexPatterns.Password)
          .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");
    }
}
