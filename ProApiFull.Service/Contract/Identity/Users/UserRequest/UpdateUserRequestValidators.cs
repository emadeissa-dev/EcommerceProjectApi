

namespace ProApiFull.Service.Contract;
public class UpdateUserRequestValidators : AbstractValidator<UpdateUserRequest>
{

    public UpdateUserRequestValidators()
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



        RuleFor(x => x.Roles)
          .NotEmpty()
            .WithMessage("{PropertyName} Is Required");

        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count())
            .WithMessage("you cannet add duplicated role")
            .When(x => x.Roles != null);
    }



}