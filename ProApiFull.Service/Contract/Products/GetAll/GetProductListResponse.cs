namespace ProApiFull.Service.Contract.Products.GetAll;
public class GetProductListResponse
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }
    public string Descrption { get; set; } = string.Empty;
    public string? CategoryName { get; set; }
    public int CountImages { get; set; }
    public List<ImageResponse>? Images { get; set; }
}
