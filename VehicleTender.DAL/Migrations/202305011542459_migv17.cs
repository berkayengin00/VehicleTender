namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTramer",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                        TramerId = c.Int(nullable: false),
                        VehiclePartStatusId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        PartPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.VehicleId, t.TramerId, t.VehiclePartStatusId })
                .ForeignKey("dbo.Tramer", t => t.TramerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.VehiclePartStatus", t => t.VehiclePartStatusId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.TramerId)
                .Index(t => t.VehiclePartStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTramer", "VehiclePartStatusId", "dbo.VehiclePartStatus");
            DropForeignKey("dbo.VehicleTramer", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleTramer", "TramerId", "dbo.Tramer");
            DropIndex("dbo.VehicleTramer", new[] { "VehiclePartStatusId" });
            DropIndex("dbo.VehicleTramer", new[] { "TramerId" });
            DropIndex("dbo.VehicleTramer", new[] { "VehicleId" });
            DropTable("dbo.VehicleTramer");
        }
    }
}
