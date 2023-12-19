using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface ICustomerRepo:IRepository<Customer>
    {
        void Login(string username, string password);
        void Logout(string username, string password);
        void SoftDelete(int id);
        List<Customer> CustomerFavoriteGenres();



    }
}
