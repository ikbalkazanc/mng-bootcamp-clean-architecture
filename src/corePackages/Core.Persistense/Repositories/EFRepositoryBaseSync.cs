using System.Linq.Expressions;
using Core.Persistense.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistense.Repositories;

public class EFRepositoryBaseSync<TEntity, TContext> : IRepository<TEntity>
    where TEntity : Entity where TContext : DbContext
{
    protected TContext Context { get; }

    public EFRepositoryBaseSync(TContext context)
    {
        Context = context;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
    }

    public IPaginate<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true
    )
    {
        IQueryable<TEntity> query = this.Query();

        if (predicate != null) query = query.Where(predicate);

        if (!enableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (orderBy != null) return orderBy(query).ToPaginate(index, size, 0);

        return query.ToPaginate(index, size, 0);
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public void Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
    }
}