using BookStore.WebApi.Application.BookOperations.GetBookDetail;
using FluentValidation;

namespace BookStore.WebApi.Validations.BookValidators
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0); // 0 dan büyük olmalı
        }
    }
}