namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VehicleAge", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VehicleAge", c => c.DateTime(nullable: false));
        }
    }
}
