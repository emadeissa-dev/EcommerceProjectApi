namespace ProApiFull.Service.Contract;
public class CreateUserRequestValidators : AbstractValidator<CreateUserRequest>
{

    public CreateUserRequestValidators()
    {
        RuleFor(x => x.FirstName)
         .NotEmpty()
         .WithMessage("{PropertyName} Is Required");

        RuleFor(x => x.LastName)
             .NotEmpty()
             .WithMessage("{PropertyName} Is Required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} Is Required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");

        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count())
            .WithMessage("you cannet add duplicated role")
            .When(x => x.Roles != null);
    }



}