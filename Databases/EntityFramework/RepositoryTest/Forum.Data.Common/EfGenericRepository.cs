using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Common
{
    public class EfGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public EfGenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public IQueryable<TEntity> All
        {
            get { return this.DbSet; }
        }

        public void Add(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;

            //this.DbSet.Add(TEntity entity);
        }

        public void Delete(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> FilterAll(Expression<Func<TEntity, bool>> filterExpr)
        {
            return this.DbSet.Where(filterExpr).ToList();
        }

        public IEnumerable<T1> SelectExp<T1>(Expression<Func<TEntity, T1>> selectExpr)
        {
            return this.DbSet.Select(selectExpr);
        }
    }
}
