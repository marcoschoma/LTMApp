using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AspNet.Security.OAuth.Validation;
using LTM.WebAPI.Security;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using LTM.Infra.Settings;
using LTM.WebAPI.DI;
using LTM.Infra.Data.Contexts;
using LTM.StartupConfig;

namespace LTM.WebAPI
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            InitializeAppSettings();

            services.AddMvc().AddJsonOptions(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddCors();

            IoC.Register(services);

            // Add authentication.
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddOAuthValidation()
            .AddOpenIdConnectServer(options =>
            {
                options.Provider = new AuthorizationProvider();
                options.TokenEndpointPath = "/connect/token";
                options.AllowInsecureHttp = true;
                options.SigningCredentials.AddEphemeralKey();
                options.AccessTokenLifetime = new TimeSpan(1, 1, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "LTM Test API", Version = "v1.0", Contact = new Contact { Name = "Marcos Braga Choma" } });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT with Bearer into field.", Name = "Authorization", Type = "apiKey" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<LTMDataContext>();
                context.Database.EnsureCreated();
                new LTMSeed(_services).EnsureSeedData();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("../swagger/v1.0/swagger.json", "Versioned Api 1.0");
            });

            // Enabled authentication.
            app.UseAuthentication();

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
        }

        private void InitializeAppSettings()
        {
            var siteSection = Configuration.GetSection("Site");
            AppSettings.Site.UrlApi = siteSection.GetValue<String>("UrlApi");
            AppSettings.Site.UrlSite = siteSection.GetValue<String>("UrlSite");

            AppSettings.ConnectionStrings.DefaultConnection = Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
