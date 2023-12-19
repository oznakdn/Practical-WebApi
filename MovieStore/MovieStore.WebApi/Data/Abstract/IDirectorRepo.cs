using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface IDirectorRepo:IRepository<Director>
    {
        void Delete(int id);
    }
}
