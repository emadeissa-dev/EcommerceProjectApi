using ProApiFull.Infrastructure;
using ProApiFull.Infrastructure.Repository;
using ProApiFull.Infrastructure.UnitOfWork;
namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private IGenericRepositoryAsync<T> _entity;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IGenericRepositoryAsync<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(context));
            }
        }

    }
}
