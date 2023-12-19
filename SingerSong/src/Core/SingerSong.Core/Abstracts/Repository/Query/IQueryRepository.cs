namespace SingerSong.Core.Abstracts.Repository.Query;

public interface IQueryRepository<T> where T : Entity<Guid>
{
    Task<T> GetAsnyc(string Id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    Task<IQueryable<T>> GetAllQueryableAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AllAnyAsync(Expression<Func<T, bool>> predicate);
}

