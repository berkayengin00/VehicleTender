namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclePartStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VehicleTramer", "VehiclePartStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleTramer", "VehicleStatus_Id", c => c.Int());
            CreateIndex("dbo.VehicleTramer", "VehicleStatus_Id");
            AddForeignKey("dbo.VehicleTramer", "VehicleStatus_Id", "dbo.VehicleStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTramer", "VehicleStatus_Id", "dbo.VehicleStatus");
            DropIndex("dbo.VehicleTramer", new[] { "VehicleStatus_Id" });
            DropColumn("dbo.VehicleTramer", "VehicleStatus_Id");
            DropColumn("dbo.VehicleTramer", "VehiclePartStatusId");
            DropTable("dbo.VehiclePartStatus");
        }
    }
}
