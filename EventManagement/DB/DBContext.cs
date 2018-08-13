using EventManagement.DB.Entities;
using System.Data.Entity;

namespace EventManagement.DB
{
    public class EventDbContext : DbContext
    {
        public EventDbContext() : base("name=EvnetManagement")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Client> Clients{ get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Audience> Audience { get; set; }

    }

}