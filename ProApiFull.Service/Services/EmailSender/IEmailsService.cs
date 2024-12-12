namespace ProApiFull.Service.Services;
public interface IEmailsService
{
    Task<string> SendEmail(string email, string Message);
}
