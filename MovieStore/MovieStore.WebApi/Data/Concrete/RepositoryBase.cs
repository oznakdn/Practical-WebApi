using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using System.Linq.Expressions;
using System.Linq;

namespace MovieStore.WebApi.Data.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context=new TContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (var context = new TContext())
            {
                return Filter is null ? context.Set<TEntity>().ToList()
                               : context.Set<TEntity>().Where(Filter).ToList();
            }
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> Filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(Filter).SingleOrDefault();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
