using Janus.Infrastructure.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Janus.Gui
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

            // GDPR Cookie Consent
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<Debug>(
                Configuration.GetSection(nameof(Debug)));

            // Authentication - WIP
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .AddRazorOptions(options =>
                {
                    options.PageViewLocationFormats.Add("/Pages/Partials/{0}.cshtml");
                });

            // MongoDb Settings
            /*
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });

            // Add DB Connection
            services.AddTransient<IJanusDbContext, JanusDbContext>();
            */

            services.AddDbContext<JanusDbContext>(options =>
                options.UseSqlServer("Server=localhost\\sqlexpress;Database=Janus;Trusted_Connection=True;Application Name=Janus;"));

            services.AddMemoryCache();
            services.AddSession();                       

            //services.AddProgressiveWebApp("manifest.json");
            //services.AddProgressiveWebApp();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            var options = new RewriteOptions().AddRedirectToHttps();
            app.UseRewriter();

            app.UseMvc();
        }
    }
}
