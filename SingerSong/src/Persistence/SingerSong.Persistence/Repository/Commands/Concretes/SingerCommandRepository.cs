namespace SingerSong.Persistence.Repository.Commands.Concretes;

public class SingerCommandRepository : CommandRepository<Singer, SingerSongDbContext>, ISingerCommandRepository
{
    public SingerCommandRepository(SingerSongDbContext context) : base(context)
    {
    }
}

