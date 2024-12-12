using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ProApiFull.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        protected readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public IQueryable<T> GetTableNoTracking()
        {
            return context.Set<T>().AsNoTracking().AsQueryable();
        }
        public virtual async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default!)
        {
            await context.Set<T>().AddRangeAsync(entities, cancellationToken);
            await context.SaveChangesAsync();
        }
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default!)
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default!)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default!)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default!)
        {
            foreach (var entity in entities)
                context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default!)
        {
            await context.SaveChangesAsync(cancellationToken);
        }



        public IDbContextTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();

        }

        public void RollBack()
        {
            context.Database.RollbackTransaction();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return context.Set<T>().AsQueryable();

        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default!)
        {
            context.Set<T>().UpdateRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default!)
        {
            return await context.Database.BeginTransactionAsync(cancellationToken);
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default!)
        {
            await context.Database.CommitTransactionAsync(cancellationToken);
        }
        public async Task RollBackAsync(CancellationToken cancellationToken = default!)
        {
            await context.Database.RollbackTransactionAsync(cancellationToken);
        }
        public async Task<bool?> ResetTable(T table, CancellationToken cancellationToken = default!)
        {
            if (await AnyAsync(cancellationToken: cancellationToken))
                return false;
            await context.Database.ExecuteSqlRawAsync(
                $"DBCC CHECKIDENT('{typeof(T).Name}',RESEED,0)", cancellationToken);
            return true;
        }
        public async Task<bool?> ResetTable(string tableName, CancellationToken cancellationToken = default!)
        {
            if (await AnyAsync(cancellationToken: cancellationToken))
                return false;
            await context.Database.ExecuteSqlRawAsync(
                $"DBCC CHECKIDENT('{tableName}',RESEED,0)", cancellationToken);
            return true;
        }
        //===========

        public async Task<List<T>> GetWithQuerySql(string querySql, CancellationToken cancellationToken = default!)
        {
            return await context.Set<T>().FromSqlRaw(querySql).ToListAsync(cancellationToken);
        }
        public async Task<List<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.ToList();
        }

        #region IncludeQueryable


        public IQueryable<T> IncludeQueryable(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>().AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (critria != null)
                query = query.Where(critria);

            return query;
        }
        public IQueryable<T> IncludeQueryableTracking(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (critria != null)
                query = query.Where(critria);

            return query;
        }

        #endregion
        #region ToListAsync
        public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!)
        {
            if (critria == null)
                return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
            return await context.Set<T>().Where(critria).ToListAsync(cancellationToken);
        }
        #endregion


        #region FirstOrDefaultAsync
        public IQueryable<T> FirstOrDefault(Expression<Func<T, bool>> critria = null!, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (critria != null)
                query = query.Where(critria);

            return query;
        }
        public T? FirstOrDefault(Expression<Func<T, bool>> Search = null!, CancellationToken cancellationToken = default!)
        {
            if (Search == null)
                return context.Set<T>().FirstOrDefault();
            return context.Set<T>().FirstOrDefault(Search);
        }
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> Search = null!, CancellationToken cancellationToken = default!)
        {
            if (Search == null)
                return await context.Set<T>().FirstOrDefaultAsync(cancellationToken);
            return await context.Set<T>().FirstOrDefaultAsync(Search, cancellationToken);
        }

        #endregion

        #region Any And AnyAsync
        public bool Any(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!)
        {
            IQueryable<T> query = context.Set<T>();
            if (critria != null)
                return query.Any(critria);
            return query.Any();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> critria = null!, CancellationToken cancellationToken = default!)
        {
            if (critria != null)
                return await context.Set<T>().AnyAsync(critria, cancellationToken);
            return await context.Set<T>().AnyAsync(cancellationToken);
        }

        #endregion

    }
}

