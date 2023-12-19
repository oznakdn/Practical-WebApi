using System;
using System.Linq;
using System.Collections.Generic;
using BookStore.WebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;
using BookStore.WebApi.Application.BookOperations.GetBooks;
using BookStore.WebApi.Application.BookOperations.GetBooks.CreateBook;
using BookStore.WebApi.Models.BookModels;
using BookStore.WebApi.Application.BookOperations.GetBookDetail;
using BookSore.WebApi.Models.BookModels;
using BookStore.WebApi.Application.BookOperations.UpdateBook;
using BookStore.WebApi.Application.BookOperations.DeleteBook;
using AutoMapper;
using BookStore.WebApi.Validations.BookValidators;
using FluentValidation.Results;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.WebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
           GetBooksQuery query=new GetBooksQuery(_dbContext,_mapper);
           var result= query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookDetailViewModel result;
            
            GetBookDetailQuery query=new GetBookDetailQuery(_dbContext,_mapper);
            query.BookId=id;
                
            GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
            
            return Ok(result);
            
            
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel book)
        {
            CreateBookCommand command=new CreateBookCommand(_dbContext,_mapper);

           
                command.Model=book;

                CreateBookCommandValidator validator=new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                return Ok();


                // ValidationResult result= validator.Validate(command);
                // if(!result.IsValid)
                // foreach (var item in result.Errors)
                // {
                //     Console.WriteLine("Özellik: " + item.PropertyName +"-Error Message: " + item.ErrorMessage);
                    
                // }
                // else
                // {
                //     command.Handle();
                // }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updateBook,int id)
        {
            
            UpdateBookCommand command =new UpdateBookCommand(_dbContext);
            command.BookId=id;
            command.Model=updateBook;

            UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            
            DeleteBookCommand command=new DeleteBookCommand(_dbContext);
            command.BookId=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }
    }
}