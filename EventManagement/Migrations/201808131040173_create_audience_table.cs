namespace EventManagement.DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_audience_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiences",
                c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 100),
                        Base64Secret = c.String(nullable: false, maxLength: 1000),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audiences");
        }
    }
}
