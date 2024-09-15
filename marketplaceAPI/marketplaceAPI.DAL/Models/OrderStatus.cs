namespace marketplaceAPI.DAL.Models
{
    public class OrderStatus : BaseEntity<int>
    {
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
