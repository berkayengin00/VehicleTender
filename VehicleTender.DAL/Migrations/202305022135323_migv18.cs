namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv18 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TenderType", newName: "UserType");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserType", newName: "TenderType");
        }
    }
}
