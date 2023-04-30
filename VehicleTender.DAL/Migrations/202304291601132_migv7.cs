namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Url", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "Url");
        }
    }
}
