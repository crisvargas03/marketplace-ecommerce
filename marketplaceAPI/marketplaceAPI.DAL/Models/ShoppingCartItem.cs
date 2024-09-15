namespace marketplaceAPI.DAL.Models
{
    public class ShoppingCartItem : BaseEntity<long>
    {
        public Guid ShoppingCartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
    }
}
