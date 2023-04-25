namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleYear", c => c.Short(nullable: false));
            DropColumn("dbo.Vehicles", "VehicleAge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleAge", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Vehicles", "VehicleYear");
        }
    }
}
