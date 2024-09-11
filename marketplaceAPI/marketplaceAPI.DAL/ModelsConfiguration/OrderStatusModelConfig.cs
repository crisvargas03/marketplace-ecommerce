using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class OrderStatusModelConfig : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.OrderStatus)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
