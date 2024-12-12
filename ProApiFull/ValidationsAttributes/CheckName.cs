using System.ComponentModel.DataAnnotations;

namespace ProApiFull.Api.ValidationsAttributes;

//[AttributeUsage(AttributeTargets.All)]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class DenayName(string name) : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value != null)
        {
            var castVal = value as string;
            if (castVal == name)
                return new ValidationResult(ErrorMessage = $"Error By Name {context.DisplayName}");

            return ValidationResult.Success!;
        }
        return ValidationResult.Success!;
    }

    //public override bool IsValid(object? value)
    //{
    //    if (value != null)
    //    {
    //        var castVal = value as string;
    //        if (castVal == name)
    //            return false;

    //        return true;
    //    }
    //    return true;
    //}
}
