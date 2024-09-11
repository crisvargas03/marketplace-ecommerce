using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class ProductPhotoModelConfig : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Path).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ProductId).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPhotos)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
