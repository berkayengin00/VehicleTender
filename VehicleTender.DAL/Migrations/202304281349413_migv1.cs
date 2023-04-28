namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorporateCustomer", "CorporatePackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.CorporateCustomer", "CorporatePackageId");
            AddForeignKey("dbo.CorporateCustomer", "CorporatePackageId", "dbo.CorporatePackage", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorporateCustomer", "CorporatePackageId", "dbo.CorporatePackage");
            DropIndex("dbo.CorporateCustomer", new[] { "CorporatePackageId" });
            DropColumn("dbo.CorporateCustomer", "CorporatePackageId");
        }
    }
}
