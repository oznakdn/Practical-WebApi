using BookStore.WebApi.Application.BookOperations.DeleteBook;
using FluentValidation;

namespace BookStore.WebApi.Validations.BookValidators
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0); // 0 dan büyük olmalı.
        }
        
    }
}