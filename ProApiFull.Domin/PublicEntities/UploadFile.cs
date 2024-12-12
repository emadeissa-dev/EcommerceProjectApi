namespace ProApiFull.Domin.PublicEntities;
public class UploadFile : AuditableEntity
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string FileExetension { get; set; } = string.Empty;
}
