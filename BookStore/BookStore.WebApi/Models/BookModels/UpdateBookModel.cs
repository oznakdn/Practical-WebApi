namespace BookStore.WebApi.Models.BookModels
{
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId{get;set;}
        
    }
}