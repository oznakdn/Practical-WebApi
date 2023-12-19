using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;
using System.Linq;

namespace MovieStore.WebApi.Data.Concrete
{
    public class CustomerRepo : RepositoryBase<Customer, MovieStoreDbContext>, ICustomerRepo
    {
        public void Login(string username, string password)
        {
            using (var context=new MovieStoreDbContext())
            {
                var user = context.Customers.SingleOrDefault(x => x.Username == username && x.Password == password);
                user.IsActive = true;
                context.SaveChanges();
            }
        }

        public void Logout(string username, string password)
        {
            using (var context = new MovieStoreDbContext())
            {
                var user = context.Customers.SingleOrDefault(x => x.Username == username && x.Password == password);

                if (user.IsActive == true) user.IsActive = false;
                else user.IsActive = false;
                context.SaveChanges();
            }
        }

        public void SoftDelete(int id)
        {
            using (var context=new MovieStoreDbContext())
            {
                var ID = context.Customers.Find(id);
                ID.IsActive = false;
                context.SaveChanges();

            }
        }

        public List<Customer>CustomerFavoriteGenres()
        {
            using (var context=new MovieStoreDbContext())
            {
                var customerFavoriteGenres = context.Customers.Include(x=>x.FavoriteGenres);
                return customerFavoriteGenres.ToList();
            }
        }



    }
}
