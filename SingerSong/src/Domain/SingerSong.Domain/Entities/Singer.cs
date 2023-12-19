using SingerSong.Core.Abstracts.Entity;
using SingerSong.Domain.Enums;

namespace SingerSong.Domain.Entities;

public class Singer : Entity<Guid>, IStatus, IAuditable
{
    public Singer()
    {
        CreatedDate = DateTime.Now;
        Albums = new HashSet<Album>();
    }

    public Singer(string singerName, SingerType singerType, MusicStyle musicStyle,string singerPhoto, string singerAbout, string location) : this()
    {
        SingerName = singerName;
        SingerType = singerType;
        MusicStyle = musicStyle;
        SingerAbout = singerAbout;
        Location = location;
        IsActive = true;
        CreatedDate = DateTime.Now;
        SingerPhoto = singerPhoto;
        Albums = new HashSet<Album>();
    }
    public string SingerName { get; set; }
    public SingerType SingerType { get; set; }
    public MusicStyle MusicStyle { get; set; }
    public string? SingerPhoto { get; set; }
    public string SingerAbout { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual ICollection<Album> Albums { get; set; }
}

