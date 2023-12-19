using MovieStore.WebApi.Models.Entities;

namespace MovieStore.WebApi.Data.Abstract
{
    public interface IOrderRepo:IRepository<Order>
    {
        void Delete(int id);
        List<Order> GetAllOrder();
    }
}
