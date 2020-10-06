using AutoMapper;
using Forum.Api.Attributes;
using Forum.Api.Extensions;
using Forum.Api.Middlewares;
using Forum.Jobs.Jobs;
using Forum.Models.NewFolder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text;

namespace Forum.Api
{
    public class ApiStartup
    {
        public ApiStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mySettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(mySettings.JwtSettings.Secret);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddControllers().AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbConfiguration(Configuration.GetConnectionString("default"));
            services.AddRepository();
            services.AddService();
            services.AddUow();
            services.AddAutoMapper(typeof(ApiStartup));
            services.AddJwtAuthenticationConfiguration(key);
            services.AddCustomAuthorizations();
            services.AddCustomPolicy();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddQuartzConfiguration(typeof(Top15ThisWeekJob));
            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

                //opt.Filters.Add(new AuthorizeFilter(policy));
                opt.Filters.Add(typeof(ModelStateValidationAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware(typeof(GlobalExceptionMidlleware));
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
