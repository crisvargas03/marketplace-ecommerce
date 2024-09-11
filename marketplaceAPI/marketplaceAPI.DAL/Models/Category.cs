namespace marketplaceAPI.DAL.Models
{
    public class Category : BaseEntity<int>
    {
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = [];
    }
}
