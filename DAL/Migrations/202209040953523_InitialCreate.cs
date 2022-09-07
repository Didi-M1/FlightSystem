namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightInfoPartials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SourceId = c.String(),
                        Long = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Source = c.String(),
                        Destination = c.String(),
                        FlightCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlightInfoPartials");
        }
    }
}
