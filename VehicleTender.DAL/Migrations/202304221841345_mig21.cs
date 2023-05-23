namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        LogTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogTypes", t => t.LogTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LogTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.LogDetails", "LogTypeId", "dbo.LogTypes");
            DropIndex("dbo.LogDetails", new[] { "UserId" });
            DropIndex("dbo.LogDetails", new[] { "LogTypeId" });
            DropTable("dbo.LogTypes");
            DropTable("dbo.LogDetails");
        }
    }
}
