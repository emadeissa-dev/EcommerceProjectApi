namespace ProApiFull.Infrastructure;

public partial class ApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainClassData).Assembly);
        ChangeBehaviorConfigrationForeignKey(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
