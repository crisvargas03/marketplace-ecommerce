namespace marketplaceAPI.DAL.Models
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Category> Categories { get; set; } = [];
        public ICollection<ProductPhoto> ProductPhotos { get; set; } = [];
    }
}
