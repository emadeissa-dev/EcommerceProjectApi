namespace ProApiFull.Service.Exetenssions;
public static class ExStringValue
{
    public static string ExTitleCase(this string value)
    {
        string[] newName = value.Split(separator: " ");
        string fullNameAfterUpdate = "";
        for (int i = 0; i < newName.Length; i++)
        {
            if (!string.IsNullOrEmpty(newName[i]))
            {
                char[] sperateCurrentName =
                    newName[i].ToString().ToCharArray();
                string singleNameAfterUpdate = "";
                for (int j = 0; j < sperateCurrentName.Length; j++)
                {
                    string newChar = "";
                    if (j == 0)
                        newChar = sperateCurrentName[j]
                            .ToString().ToUpper();
                    else
                        newChar = sperateCurrentName[j]
                            .ToString().ToLower();
                    singleNameAfterUpdate += newChar;
                }
                fullNameAfterUpdate += singleNameAfterUpdate + " ";
            }
        }
        return fullNameAfterUpdate.Trim();
    }
    public static double ExGetIntegerNumberFromString(this string Value)
    {
        char[] charsValue = Value.ToCharArray();
        string AllNumber = "";
        for (int i = 0; i < charsValue.Length; i++)
        {
            bool IsNumber = double.TryParse(charsValue[i].ToString(), out double number);
            if (IsNumber) AllNumber += charsValue[i];
        };

        return Convert.ToDouble(AllNumber);

    }
    public static string[] ExWriteOnFileTxt(this string fullPath, params string[] Data)
    {
        if (!fullPath.Contains(".txt"))
            fullPath = fullPath + ".txt";
        using StreamWriter st = new StreamWriter(fullPath, true);
        for (int i = 0; i < Data.Length; i++)
        {
            st.WriteLine(Data[i]);
        }
        st.Close();


        return Data;

    }
    public static (string, int) ExReadFromFileTxt(this string fullPath)
    {
        using StreamReader sr = new StreamReader(fullPath);
        string line = "";
        int Length = 0;
        do
        {
            Length++;
            line = sr.ReadLine();
        }
        while (line != null);
        return (line!, Length);
    }
    public static bool IsEnglish(this string value)
    {
        var englishLetters = "abcdefghijklmnopqrstuvwxyz";
        if (string.IsNullOrEmpty(value))
            return false;
        foreach (char c in value.ToLower())
            if (!englishLetters.Contains(c))
                return false;
        return true;
    }
    public static string ExGetEnglishLetters(this string value)
    {
        var englishLetters = "abcdefghijklmnopqrstuvwxyz";

        var splitValue = value.ToLower().Split(' ');
        var getString = string.Empty;
        foreach (var c in splitValue)
        {
            if (c != string.Empty || c != null)
            {
                foreach (var i in c.Trim())
                {
                    if (englishLetters.Contains(i))
                        getString += i;
                    else return null!;
                }
                getString += " ";
            }
        }
        return getString;

    }
}
