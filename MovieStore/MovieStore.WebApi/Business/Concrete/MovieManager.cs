using AutoMapper;
using FluentValidation;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Validations.MovieValidations;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IMapper _mapper;
        public MovieManager(IMovieRepo movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }
        public Movie Add(Movie entity)
        {
            return _movieRepo.Add(entity);
        }

        public List<Movie> GetAll(Expression<Func<Movie, bool>> Filter = null)
        {
            return _movieRepo.GetAll(Filter);
        }

        public List<GetAllMoviesModel> GetAllMovieWithActors()
        {
            return _movieRepo.GetAllMovieWithActors();
        }

        public Movie GetByFilter(Expression<Func<Movie, bool>> Filter)
        {
            return _movieRepo.GetByFilter(Filter);
        }

        public void SoftDelete(string Title)
        {
            var movie = _movieRepo.GetByFilter(x =>x.Title==Title);
            if (movie is null) throw new InvalidOperationException("There is no the movie for deleting");


            _movieRepo.SoftDelete(Title);
        }

        public Movie Update(Movie entity)
        {
            return _movieRepo.Update(entity);
        }

        public GetAllMoviesModel GetMovieByTitle(string Title)
        {
            var movie = _movieRepo.GetAllMovieWithActors().Where(x => x.Title == Title).SingleOrDefault();
            if(movie is null) throw new InvalidOperationException("Not found the movie");

            return movie;
        }

        public void AddMovie(CreateMovieModel model)
        {
            var movie = _movieRepo.GetByFilter(x => x.Title == model.Title);
            if (movie is not null) throw new InvalidOperationException("There is already the movie");

            CreateMovieValidator validator = new CreateMovieValidator();
            validator.ValidateAndThrow(model);

            movie = _mapper.Map<Movie>(model);
            _movieRepo.Add(movie);
        }

        public void UpdateMovie(UpdateMovieModel model, string Title)
        {
            var movie = _movieRepo.GetByFilter(x => x.Title == Title);
            if (movie is null) throw new InvalidOperationException("There is no the movie for updating");

            UpdateMovieValidator validator = new UpdateMovieValidator();
            validator.ValidateAndThrow(model);

            movie.Title = model.Title != default ? model.Title : movie.Title;
            movie.PublishDate = model.PublishDate != default ? model.PublishDate : movie.PublishDate;
            movie.MovieGenre = model.MovieGenre != default ? model.MovieGenre : movie.MovieGenre;
            movie.Price = model.Price != default ? model.Price : movie.Price;
            movie.DirectorId = model.DirectorId != default ? model.DirectorId : movie.DirectorId;

            _movieRepo.Update(movie);


        }

    }
}
