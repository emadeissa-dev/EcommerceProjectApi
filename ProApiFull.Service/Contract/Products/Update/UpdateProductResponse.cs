namespace ProApiFull.Service.Contract.Products.Update;
public class UpdateProductResponse
{

    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public double Price { get; set; }
    public string DescrptionAr { get; set; } = string.Empty;
    public string DescrptionEn { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public List<UpdateImageResponse>? Images { get; set; }
}
public class UpdateImageResponse
{

    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string FileExetension { get; set; } = string.Empty;
}
