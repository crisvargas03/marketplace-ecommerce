using marketplaceAPI.BLL.DTOs.UtilsModels;
using marketplaceAPI.BLL.Interfaces;
using marketplaceAPI.BLL.Mapper;
using marketplaceAPI.BLL.Services;
using marketplaceAPI.DAL.Context;
using marketplaceAPI.DAL.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IJwtService, JwtServices>();
        }

        private static void ConfigurateUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigurateAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var configKey = configuration["JWT:SecretKey"];
            var secretKey = Encoding.UTF8.GetBytes(configKey!);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddAuthorization();
        }

        private static void ConfigureOptionsPattner(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTConfig>(configuration.GetRequiredSection("JWT"));
        }

        private static void ConfigurateSwaggerAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(op =>
            {
                op.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                        "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                op.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        []
                    }
                });
            });
        }

        private static void ConfigurateAutomapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MapperConfigurations));
        }

        public static void ApplyServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurateAuthentication(configuration);
            services.ConfigureOptionsPattner(configuration);
            services.ConfigurateDbContext(configuration);
            services.ConfigurateSwaggerAuth();
            services.ConfigurateUnitOfWork();
            services.ConfigurateAutomapper();
            services.ConfigurateServices();
            services.ConfigurateCors();
        }
    }
}
