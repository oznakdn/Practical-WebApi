using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface ICustomerService
    {
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        void SoftDelete(int id);

        Customer GetByFilter(Expression<Func<Customer, bool>> Filter);
        List<GetAllCustomerModel> GetAllCustomer();
        List<Customer> CustomerFavoriteGenres();
        List<CustomerFavoriteGenresModel> GetAllCustomersWithFavoriteGenres();
        void AddCustomer(CreateCustomerModel model);
        void Login(string username, string password);
        void Logout(string username, string password);
        void UpdateCustomer(UpdateCustomerModel model, string username, string password);

    }
}
