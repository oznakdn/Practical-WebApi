namespace SingerSong.Core.Abstracts.Repository.Concretes;

public class QueryRepository<T, TContext> : IQueryRepository<T>
where T : Entity<Guid>
where TContext : DbContext
{
    protected readonly TContext _context;
    protected DbSet<T> _table;
    public QueryRepository(TContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public async Task<bool> AllAnyAsync(Expression<Func<T, bool>> predicate) =>await _table.AllAsync<T>(predicate);
   
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) =>await _table.AnyAsync<T>(predicate);

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;
        query = predicate is null ? query : query.Where(predicate);
        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }
        return await query.ToListAsync();

    }

    public async Task<IQueryable<T>> GetAllQueryableAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;
        query = predicate is null ? query : query.Where(predicate);
        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return await Task.Run(() => query);
    }

    public async Task<T> GetAsnyc(string Id) => await _table.SingleOrDefaultAsync(e => e.Id.Equals(Id));

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(predicate);
        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
        }

        return await query.SingleOrDefaultAsync();
    }
}

