namespace marketplaceAPI.DAL.Models
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual OrderItems? OrderItems { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<ProductPhoto>? ProductPhotos { get; set; }
        public virtual ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
