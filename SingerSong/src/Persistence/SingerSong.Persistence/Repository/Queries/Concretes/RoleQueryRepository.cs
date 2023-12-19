namespace SingerSong.Persistence.Repository.Queries.Concretes;
public class RoleQueryRepository : QueryRepository<Role, SingerSongDbContext>, IRoleQueryRepository
{
    public RoleQueryRepository(SingerSongDbContext context) : base(context)
    {
    }
}

