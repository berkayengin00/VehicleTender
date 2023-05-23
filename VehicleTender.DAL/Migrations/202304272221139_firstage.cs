namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BodyTypes", newName: "BodyType");
            RenameTable(name: "dbo.Brands", newName: "Brand");
            RenameTable(name: "dbo.BuyNows", newName: "BuyNow");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.CorporateCustomers", newName: "CorporateCustomer");
            RenameTable(name: "dbo.RetailCustomers", newName: "RetailCustomer");
            RenameTable(name: "dbo.Vehicles", newName: "Vehicle");
            RenameTable(name: "dbo.Colors", newName: "Color");
            RenameTable(name: "dbo.FuelTypes", newName: "FuelType");
            RenameTable(name: "dbo.GearTypes", newName: "GearType");
            RenameTable(name: "dbo.Models", newName: "Model");
            RenameTable(name: "dbo.ChatBots", newName: "ChatBot");
            RenameTable(name: "dbo.ChatBotUserMessages", newName: "ChatBotUser");
            RenameTable(name: "dbo.CommissionFees", newName: "CommissionFee");
            RenameTable(name: "dbo.Expertises", newName: "Expertise");
            RenameTable(name: "dbo.LogDetails", newName: "LogDetail");
            RenameTable(name: "dbo.LogTypes", newName: "LogType");
            RenameTable(name: "dbo.Messages", newName: "Message");
            RenameTable(name: "dbo.NotaryFees", newName: "NotaryFee");
            RenameTable(name: "dbo.RetailVehiclePurchases", newName: "RetailVehiclePurchase");
            RenameTable(name: "dbo.Roles", newName: "Role");
            RenameTable(name: "dbo.RoleUsers", newName: "RoleUser");
            RenameTable(name: "dbo.Stocks", newName: "Stock");
            RenameTable(name: "dbo.TenderDetails", newName: "TenderDetail");
            RenameTable(name: "dbo.Tenders", newName: "Tender");
            RenameTable(name: "dbo.TenderTypes", newName: "TenderType");
            RenameTable(name: "dbo.TenderHistories", newName: "TenderHistory");
            RenameTable(name: "dbo.Tramers", newName: "Tramer");
            RenameTable(name: "dbo.VehicleBoughtAndSolds", newName: "VehicleBoughtAndSold");
            RenameTable(name: "dbo.VehicleImages", newName: "VehicleImage");
            RenameTable(name: "dbo.VehicleStatusHistories", newName: "VehicleStatusHistory");
            RenameTable(name: "dbo.VehicleTramers", newName: "VehicleTramer");
            CreateTable(
                "dbo.CorporatePackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageName = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.BodyType", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Brand", "BrandName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.BuyNow", "AdvertName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.BuyNow", "AdvertDescription", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.User", "PasswordHash", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.CorporateCustomer", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CorporateCustomer", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CorporateCustomer", "PhoneNumber", c => c.String(nullable: false, maxLength: 11, fixedLength: true));
            AlterColumn("dbo.CorporateCustomer", "CompanyName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CorporateCustomer", "Province", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CorporateCustomer", "District", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CorporateCustomer", "Neighbourhood", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.CorporateCustomer", "CompanyType", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RetailCustomer", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RetailCustomer", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RetailCustomer", "PhoneNumber", c => c.String(nullable: false, maxLength: 11, fixedLength: true));
            AlterColumn("dbo.Vehicle", "LicensePlate", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Vehicle", "Version", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Vehicle", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.FuelType", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.GearType", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Model", "ModelName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ChatBot", "Message", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.ChatBotUser", "MessageContent", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Expertise", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Expertise", "Address", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.LogDetail", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.LogType", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Message", "Content", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.RetailVehiclePurchaseStatus", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Role", "RoleName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tender", "TenderName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.TenderType", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tramer", "TramerName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.VehicleImage", "ImagePath", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.VehicleStatus", "StatusName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleStatus", "StatusName", c => c.String());
            AlterColumn("dbo.VehicleImage", "ImagePath", c => c.String());
            AlterColumn("dbo.Tramer", "TramerName", c => c.String());
            AlterColumn("dbo.TenderType", "Name", c => c.String());
            AlterColumn("dbo.Tender", "TenderName", c => c.String());
            AlterColumn("dbo.Role", "RoleName", c => c.String());
            AlterColumn("dbo.RetailVehiclePurchaseStatus", "Name", c => c.String());
            AlterColumn("dbo.Message", "Content", c => c.String());
            AlterColumn("dbo.LogType", "Name", c => c.String());
            AlterColumn("dbo.LogDetail", "Description", c => c.String());
            AlterColumn("dbo.Expertise", "Address", c => c.String());
            AlterColumn("dbo.Expertise", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatBotUser", "MessageContent", c => c.String());
            AlterColumn("dbo.ChatBot", "Message", c => c.String());
            AlterColumn("dbo.Model", "ModelName", c => c.String());
            AlterColumn("dbo.GearType", "Name", c => c.String());
            AlterColumn("dbo.FuelType", "Name", c => c.String());
            AlterColumn("dbo.Color", "Name", c => c.String());
            AlterColumn("dbo.Vehicle", "Description", c => c.String());
            AlterColumn("dbo.Vehicle", "Version", c => c.String());
            AlterColumn("dbo.Vehicle", "LicensePlate", c => c.String(nullable: false));
            AlterColumn("dbo.RetailCustomer", "PhoneNumber", c => c.String());
            AlterColumn("dbo.RetailCustomer", "LastName", c => c.String());
            AlterColumn("dbo.RetailCustomer", "FirstName", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "CompanyType", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "Neighbourhood", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "District", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "Province", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "CompanyName", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "PhoneNumber", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "LastName", c => c.String());
            AlterColumn("dbo.CorporateCustomer", "FirstName", c => c.String());
            AlterColumn("dbo.User", "PasswordHash", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.BuyNow", "AdvertDescription", c => c.String());
            AlterColumn("dbo.BuyNow", "AdvertName", c => c.String());
            AlterColumn("dbo.Brand", "BrandName", c => c.String());
            AlterColumn("dbo.BodyType", "Name", c => c.String());
            DropTable("dbo.CorporatePackage");
            RenameTable(name: "dbo.VehicleTramer", newName: "VehicleTramers");
            RenameTable(name: "dbo.VehicleStatusHistory", newName: "VehicleStatusHistories");
            RenameTable(name: "dbo.VehicleImage", newName: "VehicleImages");
            RenameTable(name: "dbo.VehicleBoughtAndSold", newName: "VehicleBoughtAndSolds");
            RenameTable(name: "dbo.Tramer", newName: "Tramers");
            RenameTable(name: "dbo.TenderHistory", newName: "TenderHistories");
            RenameTable(name: "dbo.TenderType", newName: "TenderTypes");
            RenameTable(name: "dbo.Tender", newName: "Tenders");
            RenameTable(name: "dbo.TenderDetail", newName: "TenderDetails");
            RenameTable(name: "dbo.Stock", newName: "Stocks");
            RenameTable(name: "dbo.RoleUser", newName: "RoleUsers");
            RenameTable(name: "dbo.Role", newName: "Roles");
            RenameTable(name: "dbo.RetailVehiclePurchase", newName: "RetailVehiclePurchases");
            RenameTable(name: "dbo.NotaryFee", newName: "NotaryFees");
            RenameTable(name: "dbo.Message", newName: "Messages");
            RenameTable(name: "dbo.LogType", newName: "LogTypes");
            RenameTable(name: "dbo.LogDetail", newName: "LogDetails");
            RenameTable(name: "dbo.Expertise", newName: "Expertises");
            RenameTable(name: "dbo.CommissionFee", newName: "CommissionFees");
            RenameTable(name: "dbo.ChatBotUser", newName: "ChatBotUserMessages");
            RenameTable(name: "dbo.ChatBot", newName: "ChatBots");
            RenameTable(name: "dbo.Model", newName: "Models");
            RenameTable(name: "dbo.GearType", newName: "GearTypes");
            RenameTable(name: "dbo.FuelType", newName: "FuelTypes");
            RenameTable(name: "dbo.Color", newName: "Colors");
            RenameTable(name: "dbo.Vehicle", newName: "Vehicles");
            RenameTable(name: "dbo.RetailCustomer", newName: "RetailCustomers");
            RenameTable(name: "dbo.CorporateCustomer", newName: "CorporateCustomers");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.BuyNow", newName: "BuyNows");
            RenameTable(name: "dbo.Brand", newName: "Brands");
            RenameTable(name: "dbo.BodyType", newName: "BodyTypes");
        }
    }
}
