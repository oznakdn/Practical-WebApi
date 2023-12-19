namespace SingerSong.Persistence.Repository.Queries.Concretes;

public class AlbumQueryRepository : QueryRepository<Album, SingerSongDbContext>, IAlbumQueryRepository
{
    public AlbumQueryRepository(SingerSongDbContext context) : base(context)
    {
    }
}

