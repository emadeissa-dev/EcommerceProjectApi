namespace ProApiFull.Service.Contract;
public class ConfirmEmailRequestValidators : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidators()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Code)
            .NotEmpty()
            .NotNull();

    }

}
