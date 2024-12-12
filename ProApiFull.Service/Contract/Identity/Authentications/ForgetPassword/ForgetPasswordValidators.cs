namespace ProApiFull.Service.Contract;
public class ForgetPasswordValidators : AbstractValidator<ForgetPasswordRequest>
{

    public ForgetPasswordValidators()
    {
        RuleFor(x => x.Email)
         .NotEmpty()
         .WithMessage("{PropertyName} Is Required");

    }


}
