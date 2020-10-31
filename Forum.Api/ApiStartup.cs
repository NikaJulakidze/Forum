using Forum.Api.Attributes;
using Forum.Api.Extensions;
using Forum.Api.Middlewares;
using Forum.Models.NewFolder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

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
            services.AddCustomAutoMapperConfiguration();
            services.AddDbConfiguration(Configuration.GetConnectionString("default"));
            services.AddRepository();
            services.AddService();
            services.AddUow();
            services.AddJwtAuthenticationConfiguration(key);
            services.AddCustomAuthorizations();
            services.AddCustomPolicy();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddQuartzConfiguration(typeof(Top15ThisWeekJob));
            services.AddMvc(opt=> 
            {
                var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

                //opt.Filters.Add(new AuthorizeFilter(policy));
                opt.Filters.Add(typeof(ModelStateValidationAttribute));
                opt.EnableEndpointRouting = false;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            })
            .AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            

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
