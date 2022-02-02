using System.Linq.Expressions;
using Core.Persistense.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistense.Repositories;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    IQueryable<T> Query();
    Task<T> AddAsync(T entity);
    Task UpdateAync(T entity);
    Task DeleteAsync(T entity);
}