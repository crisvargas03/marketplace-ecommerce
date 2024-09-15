namespace marketplaceAPI.DAL.Models
{
    public class Order : BaseEntity<long>
    {
        public Guid UserId { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; } = string.Empty;
        public double TotalPrice { get; set; }

        public virtual User? User { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual ICollection<OrderItems>? OrderItems { get; set; }
    }
}
