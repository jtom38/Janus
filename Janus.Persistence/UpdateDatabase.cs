using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Janus.Persistence
{
    public class Initalize
    {
        /// <summary>
        /// This is used to apply all Migrations to the application on startup.
        /// </summary>
        /// <param name="app"></param>
        //https://blog.rsuter.com/automatically-migrate-your-entity-framework-core-managed-database-on-asp-net-core-application-start/
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<JanusDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
