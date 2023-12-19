namespace MovieStore.WebApi.Models.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int? MovieGenre { get; set; }
        public Decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public int DirectorId { get; set; }


        public virtual ICollection<Actor> Actors { get; set; }
    }
}
