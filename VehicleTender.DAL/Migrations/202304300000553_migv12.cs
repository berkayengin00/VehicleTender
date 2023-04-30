namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicle", "UserId");
            AddForeignKey("dbo.Vehicle", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "UserId", "dbo.User");
            DropIndex("dbo.Vehicle", new[] { "UserId" });
            DropColumn("dbo.Vehicle", "UserId");
        }
    }
}
