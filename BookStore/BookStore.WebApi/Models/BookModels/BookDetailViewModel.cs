namespace BookSore.WebApi.Models.BookModels
{
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author{get;set;}
        public int PageCount { get; set; }
        public string PublishDate{get;set;}
        
    }
}