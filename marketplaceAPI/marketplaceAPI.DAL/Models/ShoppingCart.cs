namespace marketplaceAPI.DAL.Models
{
    public class ShoppingCart : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = new User();
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = [];
    }
}
