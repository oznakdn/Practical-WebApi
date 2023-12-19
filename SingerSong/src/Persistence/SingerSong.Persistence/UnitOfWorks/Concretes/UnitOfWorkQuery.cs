namespace SingerSong.Persistence.UnitOfWorks.Concretes;

public class UnitOfWorkQuery : IUnitOfWorkQuery
{
    private readonly SingerSongDbContext _context;

    public UnitOfWorkQuery(SingerSongDbContext context)
    {
        _context = context;
    }

    public IAlbumQueryRepository AlbumQuery() => new AlbumQueryRepository(_context);
    public ISingerQueryRepository SingerQuery() => new SingerQueryRepository(_context);
    public IUserQueryRepository UserQuery() => new UserQueryRepository(_context);
    public IRoleQueryRepository RoleQuery() => new RoleQueryRepository(_context);

}

