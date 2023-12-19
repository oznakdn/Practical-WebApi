using AutoMapper;
using FluentValidation;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Validations.CustomerValidations;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.CustomerViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }
        public Customer Add(Customer entity)
        {
            return _customerRepo.Add(entity);
        }

        public Customer Update(Customer entity)
        {
            return _customerRepo.Update(entity);
        }

        public Customer GetByFilter(Expression<Func<Customer, bool>> Filter)
        {
            return _customerRepo.GetByFilter(Filter);
        }

        public void AddCustomer(CreateCustomerModel model)
        {
            var customer = _customerRepo.GetByFilter(x => x.Username == model.Username);
            if (customer is not null) throw new InvalidOperationException($"{model.Username} already using");

            CreateCustomerValidator validator = new CreateCustomerValidator();
            validator.ValidateAndThrow(model);

            customer = _mapper.Map<Customer>(model);
            customer.IsActive = true;
            _customerRepo.Add(customer);

        }

        public void Login(string username, string password)
        {
            var user = _customerRepo.GetByFilter(x => x.Username == username && x.Password == password);
            if (user is null) throw new InvalidOperationException("Your username or password is wrong!");

            _customerRepo.Login(username, password);
        }

        public void Logout(string username, string password)
        {
            _customerRepo.Logout(username, password);

        }

        public void UpdateCustomer(UpdateCustomerModel model, string username, string password)
        {
            var customer = _customerRepo.GetByFilter(x => x.Username == username && x.Password == password);
            if (customer is null) throw new InvalidOperationException($"Not found {username}");

            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            validator.ValidateAndThrow(model);

            customer.FirstName = model.FirstName != default ? model.FirstName : customer.FirstName;
            customer.LastName = model.LastName != default ? model.LastName : customer.LastName;
            customer.Username = model.Username != default ? model.Username : customer.Username;
            customer.Password = model.Password != default ? model.Password : customer.Password;

            _customerRepo.Update(customer);

        }

        public List<GetAllCustomerModel>GetAllCustomer()
        {
            var customer = _customerRepo.GetAll(x=>x.IsActive==true);
            return  _mapper.Map<List<GetAllCustomerModel>>(customer);
            
        }

        public void SoftDelete(int id)
        {
            var customer = _customerRepo.GetByFilter(x => x.CustomerID == id);
            if (customer is null) throw new InvalidOperationException($"Not found {id} customer for deleting ");

            _customerRepo.SoftDelete(id);
        }

        public List<Customer> CustomerFavoriteGenres()
        {
            return _customerRepo.CustomerFavoriteGenres();
        }

        public List<CustomerFavoriteGenresModel>GetAllCustomersWithFavoriteGenres()
        {
            var customerWithGenres = _customerRepo.CustomerFavoriteGenres();
            List<CustomerFavoriteGenresModel> model = _mapper.Map<List<CustomerFavoriteGenresModel>>(customerWithGenres);
            return model;
        }
    }
}
