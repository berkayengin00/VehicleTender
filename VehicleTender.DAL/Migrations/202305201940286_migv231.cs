namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv231 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishedTender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenderDetailId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OfferPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TenderDetail", t => t.TenderDetailId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TenderDetailId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinishedTender", "UserId", "dbo.User");
            DropForeignKey("dbo.FinishedTender", "TenderDetailId", "dbo.TenderDetail");
            DropIndex("dbo.FinishedTender", new[] { "UserId" });
            DropIndex("dbo.FinishedTender", new[] { "TenderDetailId" });
            DropTable("dbo.FinishedTender");
        }
    }
}
