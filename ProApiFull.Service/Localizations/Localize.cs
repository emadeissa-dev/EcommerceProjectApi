using System.Globalization;

namespace ProApiFull.Service.Localizations;
public class Localize
{



    public static string Localized()
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return "ar";
        return "en";
    }
    public static string Localized(string nameAr, string nameEn)
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return nameAr;
        return nameEn;
    }
}
