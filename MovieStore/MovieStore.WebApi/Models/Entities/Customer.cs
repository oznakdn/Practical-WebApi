using MovieStore.WebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.WebApi.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        


        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<FavoriteGenre> FavoriteGenres { get; set; }

    }
}
