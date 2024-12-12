using System.Globalization;

namespace ProApiFull.Domin.Entities;

public class AuditableEntity
{

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    [ForeignKey(nameof(CreatedBy))]
    public string CreatedById { get; set; } = string.Empty;
    [ForeignKey(nameof(UpdatedBy))]
    public string? UpdatedById { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public ApplicationUser CreatedBy { get; set; } = default!;
    public ApplicationUser? UpdatedBy { get; set; }

    public string GetLocalized(string nameAr, string nameEn)
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return nameAr;
        return nameEn;
    }
}
