namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleTramer", "VehicleStatus_Id", "dbo.VehicleStatus");
            DropIndex("dbo.VehicleTramer", new[] { "VehicleStatus_Id" });
            CreateIndex("dbo.VehicleTramer", "VehiclePartStatusId");
            AddForeignKey("dbo.VehicleTramer", "VehiclePartStatusId", "dbo.VehiclePartStatus", "Id", cascadeDelete: true);
            DropColumn("dbo.VehicleTramer", "VehicleStatus_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleTramer", "VehicleStatus_Id", c => c.Int());
            DropForeignKey("dbo.VehicleTramer", "VehiclePartStatusId", "dbo.VehiclePartStatus");
            DropIndex("dbo.VehicleTramer", new[] { "VehiclePartStatusId" });
            CreateIndex("dbo.VehicleTramer", "VehicleStatus_Id");
            AddForeignKey("dbo.VehicleTramer", "VehicleStatus_Id", "dbo.VehicleStatus", "Id");
        }
    }
}
