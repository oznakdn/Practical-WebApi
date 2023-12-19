using System;

namespace BookStore.WebApi.Models.BookModels
{
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre{get;set;}
        public string Author{get;set;}

    }
}