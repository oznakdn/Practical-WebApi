using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.DirectorViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface IDirectorService
    {
        
        Director Update(Director entity);
        List<Director> GetAll(Expression<Func<Director, bool>> Filter = null);
        Director GetByFilter(Expression<Func<Director, bool>> Filter);
        void Delete(int id);

        List<GetAllDirectorsModel> GetAllDirectors();
        GetDirectorModel GetDirectorByFullName(string firstName, string lastName);
        void AddDirector(CreateDirectorModel model);
        void UpdateDirector(UpdateDirectorModel model, int directorId);

    }
}
