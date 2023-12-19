using AutoMapper;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.OrderViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepo orderRepo, ICustomerRepo customerRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public Order Add(Order entity)
        {
            return _orderRepo.Add(entity);
        }

        public void Delete(int id)
        {
            _orderRepo.Delete(id);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> Filter = null)
        {
            return _orderRepo.GetAll(Filter);
        }

        public Order GetByFilter(Expression<Func<Order, bool>> Filter)
        {
            return _orderRepo.GetByFilter(Filter);
        }

        public Order Update(Order entity)
        {
            return _orderRepo.Update(entity);
        }
        /// <summary>
        /// A new order added when customer is loggin
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddOrder(CreateOrderModel model)
        {
            var order = _orderRepo.GetByFilter(x => x.CustomerId == model.CustomerId);

            var customerLogin = _customerRepo.GetByFilter(x => x.CustomerID == model.CustomerId);
            if (customerLogin.IsActive == false) throw new InvalidOperationException("The customer must be login");


            order = _mapper.Map<Order>(model);
            _orderRepo.Add(order);
        }

        public List<Order> GetAllOrder()
        {
            return _orderRepo.GetAllOrder();
        }

        public List<GetAllOrdersModel>GetAllOrders()
        {
            var orders = _orderRepo.GetAllOrder();
            List<GetAllOrdersModel> model = _mapper.Map<List<GetAllOrdersModel>>(orders);
            return model;
        }

        public List<GetOrdersByCustomerModel> GetOrderByCutomerName(string firsname,string lastname)
        {
          var order = _orderRepo.GetAllOrder().Where(x => x.Customer.FirstName == firsname && x.Customer.LastName == lastname).ToList();
          List<GetOrdersByCustomerModel> model = _mapper.Map<List<GetOrdersByCustomerModel>>(order);
            return model;
        }


    }
}
