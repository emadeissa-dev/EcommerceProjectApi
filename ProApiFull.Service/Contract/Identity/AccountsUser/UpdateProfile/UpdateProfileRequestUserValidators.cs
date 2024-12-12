namespace ProApiFull.Service.Contract;
public class UpdateProfileRequestUserValidators : AbstractValidator<UpdateProfileRequestUser>
{

    public UpdateProfileRequestUserValidators()
    {
        RuleFor(x => x.FirstName)
         .NotEmpty()
         .WithMessage("{PropertyName} Is Required");

        RuleFor(x => x.LastName)
         .NotEmpty()
         .WithMessage("{PropertyName} Is Required");
    }


}

