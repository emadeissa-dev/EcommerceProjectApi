namespace ProApiFull.Service.Contract.Products.GetAll;
public class GetProductByIdResponse
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Descrption { get; set; } = string.Empty;
    public string? CategoryName { get; set; }
    public int CountFiles { get; set; }
    public List<ImageResponse>? Images { get; set; }
}
