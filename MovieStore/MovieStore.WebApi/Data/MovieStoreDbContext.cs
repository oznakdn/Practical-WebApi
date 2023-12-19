using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data
{
    public class MovieStoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9DAI51M; Database=MovieStoreDB;Integrated Security=True");
        }

        

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FavoriteGenre> FavoriteGenres { get; set; }
        public DbSet<Order> Orders { get; set; }

        //public DbSet<ActorMovie> ActorMovie { get; set; }
    }
}
