namespace SingerSong.Persistence.Contexts;

public interface IDbContext
{
    DbSet<Singer> Singers { get; set; }
    DbSet<Album> Albums { get; set; }
    DbSet<Song> Songs { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }

}

