namespace MovieStore.WebApi.Models.Entities
{
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }



    }
}
