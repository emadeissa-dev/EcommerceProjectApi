using ProApiFull.Shared.Settings;

namespace ProApiFull.Service.Contract;

public class FileSizeValitor : AbstractValidator<IFormFile>
{
    public FileSizeValitor()
    {
        RuleFor(x => x)
            .Must((request, context) => request.Length <= FileSetting.MaxFileSizeInBytes)
            .WithMessage($"max file size is {FileSetting.MaxFileSizeInMB} MB  ")
            .When(x => x != null);


    }
}
