namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TenderHistory", "TenderId", "dbo.Tender");
            DropForeignKey("dbo.TenderHistory", "UserId", "dbo.User");
            DropIndex("dbo.TenderHistory", new[] { "TenderId" });
            DropIndex("dbo.TenderHistory", new[] { "UserId" });
            DropTable("dbo.TenderHistory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TenderHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TenderHistory", "UserId");
            CreateIndex("dbo.TenderHistory", "TenderId");
            AddForeignKey("dbo.TenderHistory", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TenderHistory", "TenderId", "dbo.Tender", "Id", cascadeDelete: true);
        }
    }
}
