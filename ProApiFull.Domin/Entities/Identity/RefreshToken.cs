namespace ProApiFull.Domin.Entities;

[Owned]
public class RefreshToken
{
    public string Token { get; set; }
    public DateTime ExpireOn { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? RevokeOn { get; set; }

    public bool IsExpire => DateTime.UtcNow >= ExpireOn;
    public bool IsActive => RevokeOn is null && !IsExpire;


}
