namespace marketplaceAPI.DAL.Models
{
    public class Order : BaseEntity<long>
    {
        public Guid UserId { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; } = string.Empty;
        public double TotalPrice { get; set; }

        public User User { get; set; } = new User();
        public OrderStatus OrderStatus { get; set; } = new OrderStatus();
    }
}
