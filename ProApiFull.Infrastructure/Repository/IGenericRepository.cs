using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ProApiFull.Infrastructure.Repository
{

    public interface IGenericRepositoryAsync<T> where T : class
    {
        IQueryable<T> IncludeQueryableTracking(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes);
        Task RollBackAsync(CancellationToken cancellationToken = default!);
        Task CommitAsync(CancellationToken cancellationToken = default!);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default!);
        Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default!);
        IQueryable<T> FirstOrDefault(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default!);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> IncludeQueryable(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes);
        Task<bool?> ResetTable(string tableName, CancellationToken cancellationToken = default!);
        Task SaveChangesAsync(CancellationToken cancellationToken = default!);
        Task<bool?> ResetTable(T table, CancellationToken cancellationToken = default!);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default!);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default!);
        bool Any(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!);
        Task<bool> AnyAsync(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!);
        T? FirstOrDefault(Expression<Func<T, bool>> Search = null!, CancellationToken cancellationToken = default!);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> Search = null!, CancellationToken cancellationToken = default!);
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!);
    }

}
