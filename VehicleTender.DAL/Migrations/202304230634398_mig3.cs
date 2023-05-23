namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleStatus", "StatusName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleStatus", "StatusName", c => c.Int(nullable: false));
        }
    }
}
