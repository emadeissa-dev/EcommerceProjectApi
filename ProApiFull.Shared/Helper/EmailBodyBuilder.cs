namespace ProApiFull.Shared.Helper;

public static class EmailBodyBuilder
{
    public static string GenerateEmailBody(string template, Dictionary<string, string> templateModel)
    {
        // var templatePath = $"{Directory.GetCurrentDirectory()}/ProApiFull.Service/Templates/{template}.html";
        var templatePath = "C:\\Users\\emad\\Desktop\\Every Thing Asp.net Api\\ProApiFull\\ProApiFull.Service\\Templates\\EmailConfirmation.html";
        var streamReader = new StreamReader(templatePath);
        var body = streamReader.ReadToEnd();
        streamReader.Close();

        foreach (var item in templateModel)
            body = body.Replace(item.Key, item.Value);

        return body;
    }
}