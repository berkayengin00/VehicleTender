namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tenders", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Tenders", new[] { "VehicleId" });
            RenameColumn(table: "dbo.Tenders", name: "VehicleId", newName: "Vehicle_Id");
            CreateTable(
                "dbo.TenderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenders", t => t.TenderId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.TenderId)
                .Index(t => t.VehicleId);
            
            AlterColumn("dbo.Tenders", "Vehicle_Id", c => c.Int());
            CreateIndex("dbo.Tenders", "Vehicle_Id");
            AddForeignKey("dbo.Tenders", "Vehicle_Id", "dbo.Vehicles", "Id");
            DropColumn("dbo.Tenders", "MinPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "MinPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Tenders", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.TenderDetails", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.TenderDetails", "TenderId", "dbo.Tenders");
            DropIndex("dbo.Tenders", new[] { "Vehicle_Id" });
            DropIndex("dbo.TenderDetails", new[] { "VehicleId" });
            DropIndex("dbo.TenderDetails", new[] { "TenderId" });
            AlterColumn("dbo.Tenders", "Vehicle_Id", c => c.Int(nullable: false));
            DropTable("dbo.TenderDetails");
            RenameColumn(table: "dbo.Tenders", name: "Vehicle_Id", newName: "VehicleId");
            CreateIndex("dbo.Tenders", "VehicleId");
            AddForeignKey("dbo.Tenders", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
