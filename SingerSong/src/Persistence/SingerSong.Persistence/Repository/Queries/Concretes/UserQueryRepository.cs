namespace SingerSong.Persistence.Repository.Queries.Concretes;

public class UserQueryRepository : QueryRepository<User, SingerSongDbContext>, IUserQueryRepository
{
    public UserQueryRepository(SingerSongDbContext context) : base(context)
    {
    }
}

