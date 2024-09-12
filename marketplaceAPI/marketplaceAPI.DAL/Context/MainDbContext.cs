using marketplaceAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace marketplaceAPI.DAL.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<OrderItems> OrderItems => Set<OrderItems>();
        public DbSet<OrderStatus> OrderStatus => Set<OrderStatus>();
        public DbSet<Product> Product => Set<Product>();
        public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
        public DbSet<ProductPhoto> ProductPhoto => Set<ProductPhoto>();
        public DbSet<ShoppingCart> ShoppingCart => Set<ShoppingCart>();
        public DbSet<ShoppingCartItem> ShoppingCartItem => Set<ShoppingCartItem>();
        public DbSet<User> User => Set<User>();
        public DbSet<UserRole> UserRole => Set<UserRole>();

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = Assembly.GetExecutingAssembly();
            var entitiesConfigs = assembly.GetTypes()
                .Where(t => t.Namespace == "marketplaceAPI.DAL.ModelsConfiguration"
                && t.GetInterfaces().Any(i => i.IsGenericType
                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                ).ToList();

            foreach (var entityConfig in entitiesConfigs)
            {
                dynamic configurationInstance = Activator.CreateInstance(entityConfig)!;
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
