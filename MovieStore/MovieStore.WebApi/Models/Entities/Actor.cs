namespace MovieStore.WebApi.Models.Entities
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }

    }
}
