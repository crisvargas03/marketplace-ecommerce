using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class ProductCategoryModelConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
