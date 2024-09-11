namespace marketplaceAPI.DAL.Models
{
    public class ShoppingCart : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }

        public User User { get; set; } = new User();
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = [];
    }
}
