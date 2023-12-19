using System;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
             context.Authors.AddRange(
                new Author
                {
                    FirstName="Eric",
                    LastName="Ries",
                    BirthDate=new DateTime(1978,09,22)
                },
                new Author
                {
                    FirstName="Charlotte Perkins",
                    LastName="Gilman",
                    BirthDate=new DateTime(1860,07,03)
                },
                 new Author
                {
                    FirstName="Frank",
                    LastName="Herbert",
                    BirthDate=new DateTime(1920,10,08)
                });
            context.SaveChanges();
        }
    }
}