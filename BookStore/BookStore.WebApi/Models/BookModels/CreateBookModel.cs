using System;

namespace BookStore.WebApi.Models.BookModels
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId{get;set;}
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}