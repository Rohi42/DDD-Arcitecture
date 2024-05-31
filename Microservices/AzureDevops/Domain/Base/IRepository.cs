using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Base
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> exp);
        TEntity GetById(int id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}