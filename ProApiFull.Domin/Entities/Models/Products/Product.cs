using ProApiFull.Domin.Entities.Models.Products;

namespace ProApiFull.Domin.Entities;
public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public double Price { get; set; }
    public string DescrptionAr { get; set; } = string.Empty;
    public string DescrptionEn { get; set; } = string.Empty;


    [ForeignKey(nameof(CategoryId))]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<ImageProduct>? Images { get; set; }
}
