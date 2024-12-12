using ProApiFull.Domin.Entities.Models.Products;

namespace ProApiFull.Infrastructure;

public partial class ApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ImageProduct> ImageProducts { get; set; }

}
