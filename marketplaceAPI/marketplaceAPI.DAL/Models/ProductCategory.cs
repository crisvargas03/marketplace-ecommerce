namespace marketplaceAPI.DAL.Models
{
    public class ProductCategory
    {
        public long ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}
