namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Menus", newName: "Menu");
            AlterColumn("dbo.Menu", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menu", "Name", c => c.String());
            RenameTable(name: "dbo.Menu", newName: "Menus");
        }
    }
}
