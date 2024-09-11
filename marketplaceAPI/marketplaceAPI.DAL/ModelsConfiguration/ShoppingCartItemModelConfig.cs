using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class ShoppingCartItemModelConfig : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.ShoppingCartId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.ShoppingCart)
                .WithMany(x => x.ShoppingCartItems)
                .HasForeignKey(x => x.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ShoppingCartItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
