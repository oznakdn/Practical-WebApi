namespace MovieStore.WebApi.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
