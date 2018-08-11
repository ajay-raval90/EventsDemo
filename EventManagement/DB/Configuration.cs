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
        }
    }
}