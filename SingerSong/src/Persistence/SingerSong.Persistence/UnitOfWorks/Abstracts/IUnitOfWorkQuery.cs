namespace SingerSong.Persistence.UnitOfWorks.Abstracts;

public interface IUnitOfWorkQuery
{
    IAlbumQueryRepository AlbumQuery();
    ISingerQueryRepository SingerQuery();
    IUserQueryRepository UserQuery();
    IRoleQueryRepository RoleQuery();
}

