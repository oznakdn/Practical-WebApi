using SingerSong.Core.Abstracts.Entity;

namespace SingerSong.Domain.Entities;

public class Song : Entity<Guid>, IStatus
{
    public Song()
    {

    }

    public Song(string songName, float songWeight):this()
    {
        SongName = songName;
        SongWeight = songWeight;
        IsActive = true;
    }

    public Guid AlbumID { get; set; }
    public string SongName { get; set; }
    public float SongWeight { get; set; }
    public bool IsActive { get; set; }
    public virtual Album Album { get; set; }
}

