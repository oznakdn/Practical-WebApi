namespace SingerSong.Persistence.Repository.Commands.Concretes;

public class UserCommandRepository : CommandRepository<User, SingerSongDbContext>, IUserCommandRepository
{
    public UserCommandRepository(SingerSongDbContext context) : base(context)
    {
    }
}

