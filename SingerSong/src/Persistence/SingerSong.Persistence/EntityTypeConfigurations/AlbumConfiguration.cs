namespace SingerSong.Persistence.EntityTypeConfigurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<Song>(s => s.Songs).WithOne(s => s.Album).HasForeignKey(s => s.AlbumID);
        builder.HasData(new Album
        {
            Id = new Guid("68ed7234494e44e3bce5dd5322326a65"),
            AlbumName = "Load",
            SingerID = new Guid("ee841df3532c4a788dfd9c3eac5c1d4e"),
            SongCount = 14
        });
    }
}

