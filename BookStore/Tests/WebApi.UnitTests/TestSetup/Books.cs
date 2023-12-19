using System;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book
                    {
                        Title="Lean Startup",
                        GenreId=1,
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,12),
                        AuthorId=1
                        
                    },
                    new Book
                    {
                        Title="Herland",
                        GenreId=2,
                        PageCount=250,
                        PublishDate=new DateTime(2010,05,23),
                        AuthorId=2
                        
                    },
                    new Book
                    {
                        Title="Dune",
                        GenreId=2,
                        PageCount=540,
                        PublishDate=new DateTime(2001,12,21),
                        AuthorId=3

                    });

            context.SaveChanges();
        }
    }
}