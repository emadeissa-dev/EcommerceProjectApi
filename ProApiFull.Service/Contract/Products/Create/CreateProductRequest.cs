namespace ProApiFull.Service.Contract.Products.Create;
public class CreateProductRequest
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public double Price { get; set; }
    public string DescrptionAr { get; set; } = string.Empty;
    public string DescrptionEn { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    public IFormFileCollection? Images { get; set; }
}
