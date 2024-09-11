namespace marketplaceAPI.DAL.Models
{
    public class ShoppingCartItem : BaseEntity<long>
    {
        public Guid ShoppingCartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; } = new Product();
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
    }
}
