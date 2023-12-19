using MovieStore.WebApi.Models.ViewModels.MovieViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface IRepository<T> where T:class,new()
    {
        T Add(T entity);
        T Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> Filter = null);
        T GetByFilter(Expression<Func<T, bool>> Filter);
    }
}
