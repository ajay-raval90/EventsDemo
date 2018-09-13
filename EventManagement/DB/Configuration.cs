using EventManagement.DB.Repository;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EventManagement.DB
{
    internal sealed class Configuration : DbMigrationsConfiguration<EventDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(EventDbContext context)
        {
            using (AuthRepository authRepo = new AuthRepository())
            {
                authRepo.SeedClients();
            }
            using (AudienceRepository audRepo = new AudienceRepository())
            {
                audRepo.SeedAudience();
            }
            using (EventRepository evRepo = new EventRepository())
            {
                evRepo.SeedEvents();
            }
        }
    }
}