using BookStore.WebApi.Application.BookOperations.GetBooks.CreateBook;
using FluentValidation;
using System;

namespace BookStore.WebApi.Validations.BookValidators
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
       public CreateBookCommandValidator()
       {
           RuleFor(x=>x.Model.GenreId).GreaterThan(0); // 0 dan büyük olmalı
           RuleFor(x=>x.Model.AuthorId).GreaterThan(0);
           RuleFor(x=>x.Model.PageCount).GreaterThan(0); // 0 dan büyük olmalı
           RuleFor(x=>x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date); // boş olamaz ve bugünden küçük olmalı.
           RuleFor(x=>x.Model.Title).NotEmpty().MinimumLength(2); // Boş olamaz ve dört karakterden az olamaz.
       }
    }
}