namespace EventManagement.DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_events_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        address = c.String(),
                        city = c.String(),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sessions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eventId = c.Long(nullable: false),
                        name = c.String(),
                        presenter = c.String(),
                        duration = c.String(),
                        level = c.String(),
                        _abstract = c.String(name: "abstract"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sessionId = c.Int(nullable: false),
                        ProfileId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.sessions", t => t.sessionId, cascadeDelete: true)
                .Index(t => t.sessionId)
                .Index(t => t.ProfileId);
            
            AddColumn("dbo.Events", "locationId", c => c.Int());
            AlterColumn("dbo.Events", "date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "price", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Events", "locationId");
            AddForeignKey("dbo.Events", "locationId", "dbo.locations", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sessions", "eventId", "dbo.Events");
            DropForeignKey("dbo.Voters", "sessionId", "dbo.sessions");
            DropForeignKey("dbo.Voters", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Events", "locationId", "dbo.locations");
            DropIndex("dbo.Voters", new[] { "ProfileId" });
            DropIndex("dbo.Voters", new[] { "sessionId" });
            DropIndex("dbo.sessions", new[] { "eventId" });
            DropIndex("dbo.Events", new[] { "locationId" });
            AlterColumn("dbo.Events", "price", c => c.Int());
            AlterColumn("dbo.Events", "date", c => c.DateTime());
            DropColumn("dbo.Events", "locationId");
            DropTable("dbo.Voters");
            DropTable("dbo.sessions");
            DropTable("dbo.locations");
        }
    }
}
