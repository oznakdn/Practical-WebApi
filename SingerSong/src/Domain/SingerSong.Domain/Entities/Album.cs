using SingerSong.Core.Abstracts.Entity;

namespace SingerSong.Domain.Entities;

public class Album : Entity<Guid>, IStatus, IAuditable
{

    public Album()
    {
        Songs = new HashSet<Song>();
        CreatedDate = DateTime.Now;
    }

    public Album(string albumName, int songCount, string coverPhoto, string singerId) : this()
    {
        AlbumName = albumName;
        SongCount = songCount;
        IsActive = true;
        Songs = new HashSet<Song>();
        CreatedDate = DateTime.Now;
        SingerID = Guid.Parse(singerId);
        CoverPhoto = coverPhoto;
    }

    public string AlbumName { get; set; }
    public int SongCount { get; set; }
    public string? CoverPhoto { get; set; }
    public bool IsActive { get; set; }
    public Guid SingerID { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual Singer Singer { get; set; }
    public virtual ICollection<Song> Songs { get; set; }
}
