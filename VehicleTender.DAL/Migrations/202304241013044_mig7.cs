namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tenders", "StartPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "StartPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
