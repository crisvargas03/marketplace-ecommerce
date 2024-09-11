using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplaceAPI.DAL.ModelsConfiguration
{
    public class CategoryModelConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Category { Id= 1001, Description = "Tools", CreatedBy = "Dataseed" },
                new Category { Id= 1002, Description = "Electronics", CreatedBy = "Dataseed" },
                new Category { Id= 1003, Description = "Health", CreatedBy = "Dataseed" }
            );
        }
    }
}
