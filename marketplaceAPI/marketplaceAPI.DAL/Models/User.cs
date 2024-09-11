namespace marketplaceAPI.DAL.Models
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }

        public virtual UserRole Role { get; set; } = new UserRole();
        public virtual ICollection<Order> Orders { get; set; } = [];
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = [];
    }
}
