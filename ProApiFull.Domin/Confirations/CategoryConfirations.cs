namespace ProApiFull.Domin.Confirations;
internal class CategoryConfirations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasIndex(x => new { x.NameEn, x.NameAr }).IsUnique();

        builder.Property(x => x.NameAr).HasMaxLength(150);
        builder.Property(x => x.NameEn).HasMaxLength(150);
    }
}
