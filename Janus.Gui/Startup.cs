using Janus.Domain.AppSettings;
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
using Swashbuckle.AspNetCore.Swagger;

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

            /* // If you want to use this on MsSql here you go
            services.AddDbContext<JanusDbContext>(options =>
                options.UseSqlServer("Server=localhost\\sqlexpress;Database=Janus;Trusted_Connection=True;Application Name=Janus;"));
            */

            // Lets us use IOptions<T> with DI
            services.AddOptions();
            
            // We can now DI everything under AppSettings in the json.
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            //services.AddDbContext<JanusDbContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("Sqlite")));

            services.AddDbContext<JanusDbContext>(options =>
                options.UseNpgsql($"Host={};Database=Janus;Username:"));



            services.AddMemoryCache();

            services.AddSession();
            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            */
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

            //app.ApplicationServices.GetService<JanusDbContext>().Database.Migrate();

            app.UseStaticFiles();
            var options = new RewriteOptions().AddRedirectToHttps();
            app.UseRewriter();

            app.UseMvc();

            
        }
    }
}
