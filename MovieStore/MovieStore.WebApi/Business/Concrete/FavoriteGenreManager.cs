using AutoMapper;
using FluentValidation;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Validations.FavoriteGenreValitations;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.Enums;
using MovieStore.WebApi.Models.ViewModels.FavoriteGenresModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class FavoriteGenreManager : IFavoriteGenreService
    {
        private readonly IFavoriteGenreRepo _favoriteGenreRepo;
        private readonly IMapper _mapper;

        public FavoriteGenreManager(IFavoriteGenreRepo favoriteGenreRepo, IMapper mapper)
        {
            _favoriteGenreRepo = favoriteGenreRepo;
            _mapper = mapper;
        }

        public FavoriteGenre Add(FavoriteGenre entity)
        {
            return _favoriteGenreRepo.Add(entity);
        }

        public List<FavoriteGenre> GetAll(Expression<Func<FavoriteGenre, bool>> Filter = null)
        {
            return _favoriteGenreRepo.GetAll(Filter);
        }

        public FavoriteGenre GetByFilter(Expression<Func<FavoriteGenre, bool>> Filter)
        {
            return _favoriteGenreRepo.GetByFilter(Filter);
        }

        public FavoriteGenre Update(FavoriteGenre entity)
        {
            return _favoriteGenreRepo.Update(entity);
        }

        public void AddFavoriteGenre(CreateFavoriteGenresModel model)
        {
            var favoriteGenres = _favoriteGenreRepo.GetByFilter(x => x.Genre ==(GenreEnum)model.Genres);

            CreateFavoriteGenreValidator validator = new CreateFavoriteGenreValidator();
            validator.ValidateAndThrow(model);

            favoriteGenres = _mapper.Map<FavoriteGenre>(model);
            _favoriteGenreRepo.Add(favoriteGenres);
        }
    }
}
