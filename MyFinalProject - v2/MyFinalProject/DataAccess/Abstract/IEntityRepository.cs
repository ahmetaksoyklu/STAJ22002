using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{   
    //generic constraint
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Expression<Func<T, bool>> filter = null bu ifade predicate,delege,expression yani bu ifade bize p=>p.productId=2 yazabilmemizi sağlayan ifadedir yani lambda yazabilmemizi sağalayan ifade
        //T alıyor bool döndürüyor
        //context.Set<TEntity>().SingleOrDefault(filter);
        //filtrenin true döndürdüğü nesneyi bulur ve o nesneyi geri verir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
