using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.Uow;
using Forum.Service.CustomPolicy;
using Forum.Service.Identity;
using Forum.Service.PostService;
using Forum.Service.Services.FileService;
using Forum.Service.Services.ForumService;
using Forum.Service.Services.MailService;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;

namespace Forum.Api.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
        public static void AddUow(this IServiceCollection services)
        {
            services.AddScoped<IBaseUow, BaseUow>();
            services.AddScoped<IAnswerUow, AnswerUow>();
            services.AddScoped<IForumUow, ForumUow>();
            services.AddScoped<IAdminUow, AdminUow>();
            services.AddScoped<IApplicationUserUow, ApplicationUserUow>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccountService, AccountService>();
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
                options.SignIn.RequireConfirmedEmail = true;
            })
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
        }
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
            });
        }

        public static void AddCustomAuthorizations(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                //options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                //.RequireAuthenticatedUser()
                //.Build();
                //AuthorizationPolicyBuilder a = new AdminPolicy();
                options.AddPolicy(StaticPolicies.ShouldBeAdmin, policy=>policy.Requirements.Add(new AdminPolicy()));

                options.AddPolicy("ShouldBeAdmin", policy =>
                policy.RequireClaim(StaticClaims.IsAdmin, "True")
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
            });
        }

        public static void AddJwtAuthenticationConfiguration(this IServiceCollection services,byte[] secret)
        {
            // Remove default claims
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
                   {
                       opt.TokenValidationParameters = new TokenValidationParameters
                       {
                           RequireExpirationTime = true,
                           ValidateIssuer = false,
                           ValidateAudience = false,
                           IssuerSigningKey = new SymmetricSecurityKey(secret),
                           ValidateIssuerSigningKey = true,
                           ValidateLifetime = true,
                           ClockSkew=TimeSpan.Zero
                       };
                   });
        }
        public static void AddCustomPolicy(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, AdminPolicyHandler>();
            services.AddSingleton<IAuthorizationHandler, UserPolicyHandler>();
        }
    }
}
