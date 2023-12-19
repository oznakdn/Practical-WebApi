namespace SingerSong.Persistence.Repository.Queries.Abstracts;

public interface ISingerQueryRepository:IQueryRepository<Singer>
{
    Task<Singer>GetSingerAlbumSongs(string singerId);
}

