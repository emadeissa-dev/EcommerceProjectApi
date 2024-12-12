namespace ProApiFull.Service.Contract;

public class ConfirmEmailRequest
{
    public string UserId { get; set; }
    public string Code { get; set; }

}
