namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv161 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleTramer", "TramerId", "dbo.Tramer");
            DropForeignKey("dbo.VehicleTramer", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.VehicleTramer", "VehiclePartStatusId", "dbo.VehiclePartStatus");
            DropIndex("dbo.VehicleTramer", new[] { "VehicleId" });
            DropIndex("dbo.VehicleTramer", new[] { "TramerId" });
            DropIndex("dbo.VehicleTramer", new[] { "VehiclePartStatusId" });
            DropTable("dbo.VehicleTramer");
        }
        
        public override void Down()
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
                .PrimaryKey(t => new { t.VehicleId, t.TramerId });
            
            CreateIndex("dbo.VehicleTramer", "VehiclePartStatusId");
            CreateIndex("dbo.VehicleTramer", "TramerId");
            CreateIndex("dbo.VehicleTramer", "VehicleId");
            AddForeignKey("dbo.VehicleTramer", "VehiclePartStatusId", "dbo.VehiclePartStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleTramer", "VehicleId", "dbo.Vehicle", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleTramer", "TramerId", "dbo.Tramer", "Id", cascadeDelete: true);
        }
    }
}
