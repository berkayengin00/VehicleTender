namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TenderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tenders", "TenderTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tenders", "TenderTypeId");
            AddForeignKey("dbo.Tenders", "TenderTypeId", "dbo.TenderTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Tenders", "TenderType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "TenderType", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Tenders", "TenderTypeId", "dbo.TenderTypes");
            DropIndex("dbo.Tenders", new[] { "TenderTypeId" });
            DropColumn("dbo.Tenders", "TenderTypeId");
            DropTable("dbo.TenderTypes");
        }
    }
}
