namespace MovieStore.WebApi.Models.ViewModels.OrderViewModels
{
    public class GetOrdersByCustomerModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public decimal Price { get; set; }
        public string OrderDate { get; set; }
    }
}
