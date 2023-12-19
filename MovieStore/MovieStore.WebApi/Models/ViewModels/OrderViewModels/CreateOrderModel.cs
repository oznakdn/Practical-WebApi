namespace MovieStore.WebApi.Models.ViewModels.OrderViewModels
{
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
