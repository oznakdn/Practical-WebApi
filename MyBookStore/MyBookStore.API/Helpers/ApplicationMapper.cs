using AutoMapper;
using MyBookStore.API.Data;
using MyBookStore.API.Models;

namespace MyBookStore.API.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();       
        }
    }
}
