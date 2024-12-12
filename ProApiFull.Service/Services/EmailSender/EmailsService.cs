
using MailKit.Net.Smtp;
using MimeKit;

namespace ProApiFull.Service.Services;
public class EmailsService : IEmailsService
{
    private readonly EmailSettings _emailSettings;
    public EmailsService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public async Task<string> SendEmail(string email, string Message)
    {
        try
        {

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                var bodybuilder = new BodyBuilder
                {
                    //  HtmlBody = $"{Message}",
                    HtmlBody = Message,
                    TextBody = "wellcome",
                };
                var message = new MimeMessage();

                message.Body = bodybuilder.ToMessageBody();
                message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                message.To.Add(new MailboxAddress("testing", email));
                message.Subject = "Data Test";
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            //end of sending email
            return "Success";
        }
        catch (Exception)
        {
            return "Failed";
        }
    }
}
