using MovieStore.WebApi.Models.Entities;
using MovieStore.WebApi.Models.ViewModels.OrderViewModels;
using System.Linq.Expressions;

namespace MovieStore.WebApi.Business.Abstract
{
    public interface IOrderService
    {
        Order Add(Order entity);
        Order Update(Order entity);
        void Delete(int id);

        List<Order> GetAll(Expression<Func<Order, bool>> Filter = null);
        List<Order> GetAllOrder();
        Order GetByFilter(Expression<Func<Order, bool>> Filter);
        List<GetOrdersByCustomerModel> GetOrderByCutomerName(string firsname, string lastname);

        List<GetAllOrdersModel> GetAllOrders();

        void AddOrder(CreateOrderModel model);
    }
}
