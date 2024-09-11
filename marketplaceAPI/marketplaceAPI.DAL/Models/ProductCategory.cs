namespace marketplaceAPI.DAL.Models
{
    public class ProductCategory
    {
        public long ProductId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; } = new Category();
        public Product Product { get; set; } = new Product();
    }
}
