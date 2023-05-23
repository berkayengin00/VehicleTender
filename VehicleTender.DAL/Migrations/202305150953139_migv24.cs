namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TenderHistory", "TenderDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.TenderHistory", "TenderDetailId");
            AddForeignKey("dbo.TenderHistory", "TenderDetailId", "dbo.TenderDetail", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TenderHistory", "TenderDetailId", "dbo.TenderDetail");
            DropIndex("dbo.TenderHistory", new[] { "TenderDetailId" });
            DropColumn("dbo.TenderHistory", "TenderDetailId");
        }
    }
}
