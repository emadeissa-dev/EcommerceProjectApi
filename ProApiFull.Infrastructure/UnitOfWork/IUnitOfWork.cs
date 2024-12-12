using ProApiFull.Infrastructure.Repository;

namespace ProApiFull.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepositoryAsync<T> Entity { get; }
    }
}
