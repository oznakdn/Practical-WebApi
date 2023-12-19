using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBookStore.API.Models;

namespace MyBookStore.API.Data
{
    public class MyBookStoreContext:IdentityDbContext<ApplicationUser>
    {
        public MyBookStoreContext(DbContextOptions<MyBookStoreContext>options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

    }
}
