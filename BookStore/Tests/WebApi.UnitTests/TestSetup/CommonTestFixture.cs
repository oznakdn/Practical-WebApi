using AutoMapper;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Mapping;
using Microsoft.EntityFrameworkCore;

namespace WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext context {get;set;}
        public IMapper Mapper{get;set;}

        public CommonTestFixture()
        {
            var options=new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            context=new BookStoreDbContext(options);
            context.Database.EnsureCreated();

            context.AddBooks();
            context.AddGenres();
            context.AddAuthors();

            Mapper=new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>();}).CreateMapper();

        }
    }
}