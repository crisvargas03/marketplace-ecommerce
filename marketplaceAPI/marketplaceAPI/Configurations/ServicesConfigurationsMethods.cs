using marketplaceAPI.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace marketplaceAPI.Configurations
{
    public static class ServicesConfigurationsMethods
    {
        private static void ConfigurateDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(op =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                           ?? configuration.GetConnectionString("MainDB");

                op.UseSqlServer(connectionString);
            });
        }

        private static void ConfigurateCors(this IServiceCollection services)
        {
            services.AddCors(p => p.AddPolicy("cors", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        private static void ConfigurateServices(this IServiceCollection services)
        {
        }

        private static void ConfigurateRepositories(this IServiceCollection services)
        {
        }

        public static void ApplyServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurateDbContext(configuration);
            services.ConfigurateRepositories();
            services.ConfigurateServices();
            services.ConfigurateCors();
        }
    }
}
