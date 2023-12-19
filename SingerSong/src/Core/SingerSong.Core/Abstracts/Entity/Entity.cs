namespace SingerSong.Core.Abstracts.Entity;

public abstract class Entity<TKey>
{
    public virtual TKey Id { get; set; }
}

