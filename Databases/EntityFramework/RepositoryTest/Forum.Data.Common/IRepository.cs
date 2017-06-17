using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> All { get; }

        IEnumerable<TEntity> FilterAll(Expression<Func<TEntity, bool>> filterExpr);

        IEnumerable<T1> SelectExp<T1>(Expression<Func<TEntity, T1>> filterExpr);

        TEntity GetById(object id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
