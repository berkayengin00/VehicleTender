namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tenders", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Tenders", new[] { "Vehicle_Id" });
            DropColumn("dbo.Tenders", "Vehicle_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "Vehicle_Id", c => c.Int());
            CreateIndex("dbo.Tenders", "Vehicle_Id");
            AddForeignKey("dbo.Tenders", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
    }
}
