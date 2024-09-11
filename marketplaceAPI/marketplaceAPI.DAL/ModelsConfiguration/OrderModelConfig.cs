using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class OrderModelConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x => x.TotalPrice).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OrderStatus)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
