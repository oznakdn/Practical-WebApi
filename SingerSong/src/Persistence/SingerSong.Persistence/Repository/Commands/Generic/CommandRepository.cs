namespace SingerSong.Persistence.Repository.Commands.Generic;

public class CommandRepository<T, TContext> : ICommandRepository<T>
    where T : Entity<Guid>
    where TContext : DbContext
{

    protected readonly TContext _context;
    private DbSet<T> _table;
    public CommandRepository(TContext context)
    {
        _context = context;
        _table = context.Set<T>();
    }

    public void Edit(T entity) => _table.Update(entity);
    public void EditRange(IEnumerable<T> entities) => _table.UpdateRange(entities);
    public void Insert(T entity) => _table.Add(entity);
    public void InsertRange(IEnumerable<T> entities) => _table.AddRange(entities);
    public void Remove(T entity) => _table.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _table.RemoveRange(entities);

}

