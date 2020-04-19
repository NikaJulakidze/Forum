using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.Uow;
using Forum.Service.PostService;
using Forum.Service.Services.ForumService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Forum.Api.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();
        }
        public static void AddUow(this IServiceCollection services)
        {
            services.AddScoped<IBaseUow, BaseUow>();
            services.AddScoped<IPostUow, PostUow>();
            services.AddScoped<IForumUow, ForumUow>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IForumService, ForumService>();
        }
        public static void AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
                 .AddEntityFrameworkStores<ApplicationDbContext>();
        }
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
            });
        }
    }
}
