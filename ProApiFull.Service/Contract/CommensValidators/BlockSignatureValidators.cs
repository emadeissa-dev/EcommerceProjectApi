using ProApiFull.Shared.Settings;

namespace ProApiFull.Service.Contract;

public class BlockSignatureValidators : AbstractValidator<IFormFile>
{
    public BlockSignatureValidators()
    {
        RuleFor(x => x)
            .Must((request, context) =>
            {
                BinaryReader binary = new(request.OpenReadStream());
                var bytes = binary.ReadBytes(2);

                var fileSequenceHex = BitConverter.ToString(bytes);

                foreach (var signature in FileSetting.BlockedSignatures)
                    if (signature.Equals(fileSequenceHex,
                        StringComparison.OrdinalIgnoreCase))
                        return false;

                return true;
            })
             .WithMessage("Not allowed file content")
             .When(x => x is not null);
    }
}
