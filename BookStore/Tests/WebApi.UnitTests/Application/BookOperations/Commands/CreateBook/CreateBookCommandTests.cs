using System;
using AutoMapper;
using BookStore.WebApi.Application.BookOperations.GetBooks.CreateBook;
using BookStore.WebApi.DBOperations;
using BookStore.WebApi.Entities;
using BookStore.WebApi.Models.BookModels;
using FluentAssertions;
using WebApi.UnitTests.TestSetup;
using Xunit;
using System.Linq;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationExeption_ShouldBeReturn()
        {
            // arrange : hazırlık
            var book=new Book()
            {
                Title="WhenAlreadyExistBookTitleIsGiven_InvalidOperationExeption_ShouldBeReturn",
                PageCount=100,
                PublishDate=new DateTime(1990,01,20),
                GenreId=1,
                AuthorId=2
            };
            _context.Add(book);
            _context.SaveChanges();

            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel(){Title=book.Title};

            // act & assert : çalıştırma & doğrulama

            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }

        [Fact]
        public void WhenValidaInputAreGiven_Book_ShouldBeCreated()
        {

            //arrange
            CreateBookCommand command=new CreateBookCommand(_context,_mapper);
            CreateBookModel model=new CreateBookModel()
            {
                Title="Hobbit",
                PageCount=1000,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=1,
                AuthorId=2
            };
            command.Model=model;

            //act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            //assert
            var book=_context.Books.SingleOrDefault(x=>x.Title==model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);



        }
    }
}