namespace ProApiFull.Service.Contract.Roles.RoleRequestModel;
public class RoleRequestValidators : AbstractValidator<RoleRequest>
{
    public RoleRequestValidators()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 15);

        RuleFor(x => x.Permissions)
          .NotEmpty()
          .NotNull();

        RuleFor(x => x.Permissions)
            .Must(x => x.Distinct().Count() == x.Count())
            .WithMessage("you cannot add duplicated permission".ExTitleCase())
            .When(x => x.Permissions != null);



    }

}
