namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CorporateCustomers", "CorporateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CorporateCustomers", "CorporateId", c => c.Int(nullable: false));
        }
    }
}
