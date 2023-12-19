namespace SingerSong.Persistence.EntityTypeConfigurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasData(new Song
        {
            Id = new Guid("54fa52b2893d4603954f348a12ad98b2"),
            AlbumID=new Guid("68ed7234494e44e3bce5dd5322326a65"),
            SongName = "Wasting my hate",
            SongWeight = 3.57f
        });
    }
}

