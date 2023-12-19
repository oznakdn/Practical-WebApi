namespace MovieStore.WebApi.Models.Entities
{
    public class Director
    {
        public int DirectorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }


    }
}
