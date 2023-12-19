namespace SingerSong.Persistence.UnitOfWorks.Abstracts;

public interface IUnitOfWorkCommand : IAsyncDisposable
{
    IAlbumCommandRepository AlbumCommand();
    ISingerCommandRepository SingerCommand();
    IUserCommandRepository UserCommand();
    IRoleCommandRepository RoleCommand();
    Task<int> SaveAsync();
}

