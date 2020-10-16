using System;
using System.IdentityModel.Tokens.Jwt;
using CommonModels.StaticSettings;
using Forum.WebUI.Attributes;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Forum.WebUI.StaticSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Forum.WebUI
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
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddHttpClient<IApiCallService,ApiCallService>(client => 
            {
                //client.BaseAddress = new Uri(Configuration.GetSection("AppSettings").Get<AppSettings>().BaseAddress);
                client.BaseAddress = new Uri(ApiCallStaticRoutes.BaseUrl);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(opt=>
            {
                opt.Filters.Add(typeof(ModelStateValidationAttribute));
            });

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddAuthentication(opt => {

                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc",opt=> 
                {
                    opt.Authority = StaticUrls.IdentityServerUrl;
                    //opt.RequireHttpsMetadata = false;

                    opt.ClientId = StaticClienIDs.ForumMvcId;
                    opt.ClientSecret = StaticCliendSecrets.ForumMvcSecret;
                    opt.ResponseType = "code";

                    opt.SaveTokens = true;
                });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Privacy}/{id?}");

                endpoints.MapHub<TetsHubClass>("/chathub");
            });
        }
    }
}
