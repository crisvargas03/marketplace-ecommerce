namespace marketplaceAPI.DAL.Models
{
    public class ProductPhoto : BaseEntity<long>
    {
        public string Path { get; set; } = string.Empty;
        public long ProductId { get; set; }

        public Product Product { get; set; } = new Product();
    }
}
