using System.Linq.Expressions;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class EfRepositoryBase<TEntity, TEntityId, TContext> :
    IAsyncRepository<TEntity, TEntityId>,
    IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public virtual IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false,
        bool enableTracking = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

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

        return query;
    }

    public virtual async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            include: include,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            include: include,
            orderBy: orderBy,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return await query.AnyAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.CreatedDate = now;
        }

        await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.UpdatedDate = now;
        }

        Context.Set<TEntity>().UpdateRange(entities);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default)
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

        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default)
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

        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public virtual TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            include: include,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return query.FirstOrDefault();
    }

    public virtual IReadOnlyList<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false,
        bool enableTracking = true)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            include: include,
            orderBy: orderBy,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return query.ToList();
    }

    public virtual bool Any(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true)
    {
        IQueryable<TEntity> query = Query(
            predicate: predicate,
            withDeleted: withDeleted,
            enableTracking: enableTracking);

        return query.Any();
    }

    public virtual TEntity Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public virtual ICollection<TEntity> AddRange(ICollection<TEntity> entities)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.CreatedDate = now;
        }

        Context.Set<TEntity>().AddRange(entities);
        Context.SaveChanges();
        return entities;
    }

    public virtual TEntity Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public virtual ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
    {
        DateTime now = DateTime.UtcNow;
        foreach (TEntity entity in entities)
        {
            entity.UpdatedDate = now;
        }

        Context.Set<TEntity>().UpdateRange(entities);
        Context.SaveChanges();
        return entities;
    }

    public virtual TEntity Delete(TEntity entity, bool permanent = false)
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

        Context.SaveChanges();
        return entity;
    }

    public virtual ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = false)
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

        Context.SaveChanges();
        return entities;
    }
}
