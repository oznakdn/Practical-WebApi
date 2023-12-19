using BookStore.WebApi.Application.BookOperations.UpdateBook;
using FluentValidation;

namespace BookStore.WebApi.Validations.BookValidators
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0); // 0 dan büyük olmalı.
            RuleFor(x=>x.Model.GenreId).GreaterThan(0); // 0 dan büyük olmalı.
            RuleFor(x=>x.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}