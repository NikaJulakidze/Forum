using AutoMapper;
using CommonModels;
using Forum.AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;
using Forum.Jobs.Factory;
using Forum.Jobs.HostedService;
using Forum.Jobs.Jobs;
using Forum.Jobs.Scheduler;
using Forum.Service.CustomPolicy;
using Forum.Service.Identity;
using Forum.Service.PostService;
using Forum.Service.Services.FileService;
using Forum.Service.Services.ForumService;
using Forum.Service.Services.MailService;
using Forum.Service.Services.QuestionService;
using Forum.Service.Services.TagService;
using Forum.Service.Uri;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
            services.AddScoped<ITagPostRepository, TagPostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IRatingPointsHistoryRepository, RatingPointsHistoryRepository>();
        }

        public static void AddUow(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITagService, TagService>();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
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
        
        public static void AddCustomAuthorizations(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                //options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                //.RequireAuthenticatedUser()
                //.Build();
                //AuthorizationPolicyBuilder a = new AdminPolicy();
                //options.AddPolicy(StaticPolicies.ApiScope, policy=> 
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.RequireClaim("", "");
                //});
            });
        }

        public static void AddJwtAuthenticationConfiguration(this IServiceCollection services,byte[] secret)
        {
            // Remove default claims
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
                   {
                       opt.Audience = StaticSettings.ApiUrl;
                       opt.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateAudience = false,
                           RequireExpirationTime = true,
                           ValidateIssuer = false,
                           IssuerSigningKey = new SymmetricSecurityKey(secret),
                           ValidateIssuerSigningKey = true,
                           ValidateLifetime = true,
                           ClockSkew = TimeSpan.Zero
                       };
                   });
        }
        public static void AddCustomPolicy(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, AdminPolicyHandler>();
            services.AddSingleton<IAuthorizationHandler, UserPolicyHandler>();
        }

        public static void AddQuartzConfiguration(this IServiceCollection services, params Type[] jobs)
        {
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.Add(jobs.Select(jobType => new ServiceDescriptor(jobType, jobType, ServiceLifetime.Singleton)));

            services.AddSingleton(new JobSchedule(typeof(BirthDayGiftJob), "0/5 * * * * ?"));
            services.AddSingleton(new JobSchedule(typeof(AnniversaryGiftJob), "0/5 * * * * ?"));
            services.AddSingleton(new JobSchedule(typeof(Top15ThisWeekJob), "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }
        
        public static void AddCustomAutoMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ForumMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
