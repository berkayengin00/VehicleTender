namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclePrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehiclePrice", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.VehiclePrice", new[] { "VehicleId" });
            DropTable("dbo.VehiclePrice");
        }
    }
}
