using AutoMapper;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.MovieViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStore.Tests.MovieTests.CrudTests
{
    public class MovieCreateTests
    {

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        

        [Fact]
        public void Movie_Create_Given_Parameter()
        {

            // Arrange
            CreateMovieModel model = new CreateMovieModel()
            {
                Title = "test",
                DirectorId = 1,
                MovieGenre = 1,
                Price = 1,
                PublishDate = DateTime.Now
            };

            // Act
            _movieService.AddMovie(model);

            // Assert
            var movie = new Movie();
            Assert.Equal(movie.Title, model.Title);
            Assert.Equal(movie.DirectorId, model.DirectorId);
            Assert.Equal(movie.MovieGenre, model.MovieGenre);
            Assert.Equal(movie.Price, model.Price);
            Assert.Equal(movie.PublishDate, model.PublishDate);








        }
    }
}
