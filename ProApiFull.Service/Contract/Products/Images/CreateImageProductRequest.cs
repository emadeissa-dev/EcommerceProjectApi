namespace ProApiFull.Service.Contract.Products.Create;
public class CreateImageProductRequest
{
    public IFormFileCollection? Files { get; set; }
    public int ProductId { get; set; }
}
