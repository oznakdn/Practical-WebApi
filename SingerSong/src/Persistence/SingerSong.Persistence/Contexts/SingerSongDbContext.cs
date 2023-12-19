namespace SingerSong.Persistence.Contexts;

public class SingerSongDbContext : DbContext, IDbContext
{
    public SingerSongDbContext(DbContextOptions<SingerSongDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Singer> Singers { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Song> Songs { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new SingerConfiguration());
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

