namespace SingerSong.Persistence.UnitOfWorks.Concretes;

public class UnitOfWorkCommand : IUnitOfWorkCommand
{
    private readonly SingerSongDbContext _context;

    public UnitOfWorkCommand(SingerSongDbContext context)
    {
        _context = context;
    }

    public IAlbumCommandRepository AlbumCommand() => new AlbumCommandRepository(_context);
    public ISingerCommandRepository SingerCommand() => new SingerCommandRepository(_context);
    public IUserCommandRepository UserCommand() => new UserCommandRepository(_context);
    public IRoleCommandRepository RoleCommand() => new RoleCommandRepository(_context);

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


}

