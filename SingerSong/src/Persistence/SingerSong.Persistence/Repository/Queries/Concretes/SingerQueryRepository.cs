namespace SingerSong.Persistence.Repository.Queries.Concretes;

public class SingerQueryRepository : QueryRepository<Singer, SingerSongDbContext>, ISingerQueryRepository
{
    public SingerQueryRepository(SingerSongDbContext context) : base(context)
    {
    }

    public async Task<Singer> GetSingerAlbumSongs(string singerId) => await _context.Singers.Where(x=>x.Id==Guid.Parse(singerId)).Include(x => x.Albums).ThenInclude(x => x.Songs).SingleOrDefaultAsync();

}

