namespace ProApiFull.Infrastructure;

public partial class ApplicationDbContext
{
    private void ChangeBehaviorConfigrationForeignKey(ModelBuilder modelBuilder)
    {
        var cascadeKeys = modelBuilder.Model
                        .GetEntityTypes()
                        .SelectMany(x => x.GetForeignKeys())
                           .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade
                           && !fk.IsOwnership);

        foreach (var foreignKey in cascadeKeys)
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
