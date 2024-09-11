namespace marketplaceAPI.DAL.Models
{
    public class Category : BaseEntity<int>
    {
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = [];
    }
}
