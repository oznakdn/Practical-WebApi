namespace SingerSong.Persistence.Repository.Commands.Concretes;

public class AlbumCommandRepository : CommandRepository<Album, SingerSongDbContext>, IAlbumCommandRepository
{
    public AlbumCommandRepository(SingerSongDbContext context) : base(context)
    {
    }
}

