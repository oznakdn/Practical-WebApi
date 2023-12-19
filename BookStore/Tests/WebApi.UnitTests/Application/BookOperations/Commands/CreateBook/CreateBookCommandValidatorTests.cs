using System;
using BookStore.WebApi.Application.BookOperations.GetBooks.CreateBook;
using BookStore.WebApi.Models.BookModels;
using BookStore.WebApi.Validations.BookValidators;
using FluentAssertions;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeResturnErrors()
        {
            // arrange : hazırlık
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel()
            {
                Title="",
                PageCount=0,
                PublishDate=DateTime.Now.Date,
                GenreId=0,
                AuthorId=0,
            };

            // act: çalıştırma

            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result=validator.Validate(command);

            // assert: kontrol
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // arrange : hazırlık
            CreateBookCommand command=new CreateBookCommand(null,null);
            command.Model=new CreateBookModel()
            {
                Title="Lord Of The Rings",
                PageCount=100,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=1,
                AuthorId=2,
            };

            // act: çalıştırma

            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result=validator.Validate(command);

            // assert: kontrol
            result.Errors.Count.Should().Be(0);
            
        }
      
    }
}