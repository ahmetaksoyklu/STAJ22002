using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IQuery<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
{
    IQueryable<TEntity> Query(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool withDeleted = false,
        bool enableTracking = true);
}
