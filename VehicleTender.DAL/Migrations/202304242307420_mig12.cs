namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserType", c => c.Int(nullable: false));
        }
    }
}
