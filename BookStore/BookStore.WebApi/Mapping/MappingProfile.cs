using AutoMapper;
using BookSore.WebApi.Models.BookModels;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Models.AuthorModels;
using BookStore.WebApi.Models.BookModels;
using BookStore.WebApi.Models.GenreModels;
using BookStore.WebApi.Models.UserModels;

namespace BookStore.WebApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            // Books Mapping
            CreateMap<CreateBookModel,Book>(); // CreatBookModel objesi , Book objesine mapplenebilir.
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.FirstName+" "+src.Author.LastName));

            CreateMap<Book,BooksViewModel>().ForMember(x=>x.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.FirstName+" "+src.Author.LastName));

            // Genres Mapping
            CreateMap<Genre,GenresViewModel>(); // GetAllGenres
            CreateMap<Genre,GenreDetailViewModel>(); // GetGenre
            CreateMap<CreateGenreModel,Genre>(); // Create Genre

            //Author Mapping
            CreateMap<Author,AuthorsViewModel>() //GetAll Authors
            .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.FirstName))
            .ForMember(dest=>dest.LastName,opt=>opt.MapFrom(src=>src.LastName))
            .ForMember(dest=>dest.BirthDate,opt=>opt.MapFrom(src=>src.BirthDate));

            CreateMap<Author,AuthorDetailViewModel>(); //GetAuthor
            CreateMap<CreateAuthorModel,Author>(); //CreateAuthor
           
           CreateMap<CreateUserModel,User>(); //CreateUser

            
        }
    }
}