namespace SingerSong.Core.Abstracts.Repository.Command;

public interface ICommandRepository<T> where T : Entity<Guid>
{
    void Insert(T entity);
    void InsertRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Edit(T entity);
    void EditRange(IEnumerable<T> entities);
}

