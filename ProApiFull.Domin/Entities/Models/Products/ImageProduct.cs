using ProApiFull.Domin.PublicEntities;

namespace ProApiFull.Domin.Entities.Models.Products;
public class ImageProduct : UploadFile
{
    public bool IsUpdatedOrDeleted { get; set; } = false;
    [ForeignKey(nameof(ProductId))]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
