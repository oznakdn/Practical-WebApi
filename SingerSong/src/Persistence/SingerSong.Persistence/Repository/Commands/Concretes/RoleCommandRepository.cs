namespace SingerSong.Persistence.Repository.Commands.Concretes;

public class RoleCommandRepository : CommandRepository<Role, SingerSongDbContext>, IRoleCommandRepository
{
    public RoleCommandRepository(SingerSongDbContext context) : base(context)
    {
    }
}

