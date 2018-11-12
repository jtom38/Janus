using Janus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Janus.Persistence
{
    public class JanusDbContext : DbContext
    {
        public JanusDbContext(DbContextOptions<JanusDbContext> options) : base (options)
        {
            
        }
        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ComputerID> ComputerIDs { get; set; }
        public DbSet<HardDrives> HardDrives { get; set; }
        public DbSet<Network> Network { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Techs> Techs { get; set; }
        public DbSet<TenantID> TenantIDs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketComments> TicketComments { get; set; }
        public DbSet<WindowsUpdates> WindowsUpdates { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
        */
    }
}
