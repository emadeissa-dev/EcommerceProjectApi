namespace ProApiFull.Domin.Confirations;
internal class ProductsConfirations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(x => new { x.NameEn, x.NameAr }).IsUnique();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NameAr).HasMaxLength(150);
        builder.Property(x => x.NameEn).HasMaxLength(150);
        builder.Property(x => x.DescrptionAr).HasMaxLength(400);
        builder.Property(x => x.DescrptionEn).HasMaxLength(400);



    }
}
