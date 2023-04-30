namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migv131 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ProvinceId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Province", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CorporateCustomer", "District_Id", c => c.Int());
            AddColumn("dbo.CorporateCustomer", "DistrictId", c => c.String(nullable: false));
            CreateIndex("dbo.CorporateCustomer", "District_Id");
            AddForeignKey("dbo.CorporateCustomer", "District_Id", "dbo.District", "Id");
            DropColumn("dbo.CorporateCustomer", "Province");
            DropColumn("dbo.CorporateCustomer", "District");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CorporateCustomer", "District", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.CorporateCustomer", "Province", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.CorporateCustomer", "District_Id", "dbo.District");
            DropForeignKey("dbo.District", "ProvinceId", "dbo.Province");
            DropIndex("dbo.CorporateCustomer", new[] { "District_Id" });
            DropIndex("dbo.District", new[] { "ProvinceId" });
            DropColumn("dbo.CorporateCustomer", "DistrictId");
            DropColumn("dbo.CorporateCustomer", "District_Id");
            DropTable("dbo.Province");
            DropTable("dbo.District");
        }
    }
}
