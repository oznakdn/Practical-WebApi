using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.DBOperations
{
    public interface IBookStoreDbContext
    {
         DbSet<Book>Books{get;set;}
         DbSet<Genre>Genres{get;set;}
         DbSet<Author>Authors{get;set;}

         int SaveChanges();





    }
}