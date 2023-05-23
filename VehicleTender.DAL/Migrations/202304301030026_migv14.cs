namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CorporateCustomer", "District_Id", "dbo.District");
            DropIndex("dbo.CorporateCustomer", new[] { "District_Id" });
            DropColumn("dbo.CorporateCustomer", "DistrictId");
            RenameColumn(table: "dbo.CorporateCustomer", name: "District_Id", newName: "DistrictId");
            AlterColumn("dbo.CorporateCustomer", "DistrictId", c => c.Int(nullable: false));
            AlterColumn("dbo.CorporateCustomer", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.CorporateCustomer", "DistrictId");
            AddForeignKey("dbo.CorporateCustomer", "DistrictId", "dbo.District", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorporateCustomer", "DistrictId", "dbo.District");
            DropIndex("dbo.CorporateCustomer", new[] { "DistrictId" });
            AlterColumn("dbo.CorporateCustomer", "DistrictId", c => c.String(nullable: false));
            AlterColumn("dbo.CorporateCustomer", "DistrictId", c => c.Int());
            RenameColumn(table: "dbo.CorporateCustomer", name: "DistrictId", newName: "District_Id");
            AddColumn("dbo.CorporateCustomer", "DistrictId", c => c.String(nullable: false));
            CreateIndex("dbo.CorporateCustomer", "District_Id");
            AddForeignKey("dbo.CorporateCustomer", "District_Id", "dbo.District", "Id");
        }
    }
}
