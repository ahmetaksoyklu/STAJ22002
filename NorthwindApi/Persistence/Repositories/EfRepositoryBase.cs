using System.Linq.Expressions;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Repositories;

public class EfRepositoryBase<TEntity, TEntityId, TContext> :
    IAsyncRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public virtual IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();

        if (withDeleted)
            query = query.IgnoreQueryFilters();

        if (!enableTracking)
            query = query.AsNoTracking();

        query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<List<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();

        if (withDeleted)
            query = query.IgnoreQueryFilters();

        if (!enableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        if (orderBy is not null)
            query = orderBy(query);

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();

        if (withDeleted)
            query = query.IgnoreQueryFilters();

        if (!enableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        return await query.AnyAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.CreatedDate = now;
        }

        await Context.Set<TEntity>().AddRangeAsync(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.UpdatedDate = now;
        }

        Context.Set<TEntity>().UpdateRange(entities);
        await Context.SaveChangesAsync();
        return entities;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        if (permanent)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        else
        {
            entity.DeletedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Update(entity);
        }

        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
    {
        if (permanent)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        else
        {
            DateTime now = DateTime.UtcNow;
            foreach (TEntity entity in entities)
            {
                entity.DeletedDate = now;
                entity.UpdatedDate = now;
            }

            Context.Set<TEntity>().UpdateRange(entities);
        }

        await Context.SaveChangesAsync();
        return entities;
    }
}
