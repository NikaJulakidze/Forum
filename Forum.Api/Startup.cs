using AutoMapper;
using Forum.Api.Attributes;
using Forum.Api.Extensions;
using Forum.Api.Middlewares;
using Forum.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text;

namespace Forum.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mySettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(mySettings.Secret);
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.AddControllers();
            services.AddSwaggerConfiguration();
            services.AddDbConfiguration(Configuration.GetConnectionString("default"));
            services.AddRepository();
            services.AddService();
            services.AddUow();
            services.AddAutoMapper(typeof(Startup));
            services.AddJwtAuthenticationConfiguration(key);
            services.AddCustomAuthorizations();
            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder("Bearer")
                .RequireAuthenticatedUser()
                .Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
                opt.Filters.Add(typeof(ModelStateValidationAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

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
