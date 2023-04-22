namespace VehicleTender.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BuyNows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        AdvertName = c.String(),
                        AdvertDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        IsVerify = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UserType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleAge = c.DateTime(nullable: false),
                        Version = c.String(),
                        KiloMeter = c.Int(nullable: false),
                        Description = c.String(),
                        GearTypeId = c.Int(nullable: false),
                        FuelTypeId = c.Int(nullable: false),
                        BodyTypeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.GearTypes", t => t.GearTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.GearTypeId)
                .Index(t => t.FuelTypeId)
                .Index(t => t.BodyTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GearTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        BrandId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.ChatBots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        AltMessage = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChatBotUserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatBotId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MessageContent = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChatBots", t => t.ChatBotId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChatBotId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommissionFees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        VehicleMinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleMaxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageTitle = c.String(),
                        Content = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NotaryFees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RetailVehiclePurchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        RetailVehiclePurchaseStatusId = c.Int(nullable: false),
                        PreliminaryValuationPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuotedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoldId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RetailVehiclePurchaseStatus", t => t.RetailVehiclePurchaseStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.RetailVehiclePurchaseStatusId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RetailVehiclePurchaseStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PreliminaryValuationPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TenderHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenders", t => t.TenderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TenderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        TenderStatusId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        TenderType = c.Boolean(nullable: false),
                        StartPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TenderStatus", t => t.TenderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.TenderStatusId);
            
            CreateTable(
                "dbo.TenderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tramers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TramerName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleBoughtAndSolds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        BoughtId = c.Int(nullable: false),
                        SoldId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.VehicleImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.VehicleStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleStatusHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        VehicleStatusId = c.Int(nullable: false),
                        StatusChangeDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleStatus", t => t.VehicleStatusId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.VehicleStatusId);
            
            CreateTable(
                "dbo.VehicleTramers",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                        TramerId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleId, t.TramerId })
                .ForeignKey("dbo.Tramers", t => t.TramerId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.TramerId);
            
            CreateTable(
                "dbo.CorporateCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        CompanyName = c.String(),
                        Province = c.String(),
                        District = c.String(),
                        Neighbourhood = c.String(),
                        CompanyType = c.String(),
                        CorporateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RetailCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RetailCustomers", "Id", "dbo.Users");
            DropForeignKey("dbo.CorporateCustomers", "Id", "dbo.Users");
            DropForeignKey("dbo.VehicleTramers", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleTramers", "TramerId", "dbo.Tramers");
            DropForeignKey("dbo.VehicleStatusHistories", "VehicleStatusId", "dbo.VehicleStatus");
            DropForeignKey("dbo.VehicleStatusHistories", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleImages", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleBoughtAndSolds", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleBoughtAndSolds", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TenderHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.TenderHistories", "TenderId", "dbo.Tenders");
            DropForeignKey("dbo.Tenders", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Tenders", "TenderStatusId", "dbo.TenderStatus");
            DropForeignKey("dbo.Stocks", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Stocks", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RetailVehiclePurchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.RetailVehiclePurchases", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RetailVehiclePurchases", "RetailVehiclePurchaseStatusId", "dbo.RetailVehiclePurchaseStatus");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChatBotUserMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChatBotUserMessages", "ChatBotId", "dbo.ChatBots");
            DropForeignKey("dbo.BuyNows", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Vehicles", "GearTypeId", "dbo.GearTypes");
            DropForeignKey("dbo.Vehicles", "FuelTypeId", "dbo.FuelTypes");
            DropForeignKey("dbo.Vehicles", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.BuyNows", "User_Id", "dbo.Users");
            DropIndex("dbo.RetailCustomers", new[] { "Id" });
            DropIndex("dbo.CorporateCustomers", new[] { "Id" });
            DropIndex("dbo.VehicleTramers", new[] { "TramerId" });
            DropIndex("dbo.VehicleTramers", new[] { "VehicleId" });
            DropIndex("dbo.VehicleStatusHistories", new[] { "VehicleStatusId" });
            DropIndex("dbo.VehicleStatusHistories", new[] { "VehicleId" });
            DropIndex("dbo.VehicleImages", new[] { "VehicleId" });
            DropIndex("dbo.VehicleBoughtAndSolds", new[] { "User_Id" });
            DropIndex("dbo.VehicleBoughtAndSolds", new[] { "VehicleId" });
            DropIndex("dbo.Tenders", new[] { "TenderStatusId" });
            DropIndex("dbo.Tenders", new[] { "VehicleId" });
            DropIndex("dbo.TenderHistories", new[] { "UserId" });
            DropIndex("dbo.TenderHistories", new[] { "TenderId" });
            DropIndex("dbo.Stocks", new[] { "UserId" });
            DropIndex("dbo.Stocks", new[] { "VehicleId" });
            DropIndex("dbo.RoleUsers", new[] { "UserId" });
            DropIndex("dbo.RoleUsers", new[] { "RoleId" });
            DropIndex("dbo.RetailVehiclePurchases", new[] { "User_Id" });
            DropIndex("dbo.RetailVehiclePurchases", new[] { "RetailVehiclePurchaseStatusId" });
            DropIndex("dbo.RetailVehiclePurchases", new[] { "VehicleId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.ChatBotUserMessages", new[] { "UserId" });
            DropIndex("dbo.ChatBotUserMessages", new[] { "ChatBotId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropIndex("dbo.Vehicles", new[] { "ColorId" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropIndex("dbo.Vehicles", new[] { "BodyTypeId" });
            DropIndex("dbo.Vehicles", new[] { "FuelTypeId" });
            DropIndex("dbo.Vehicles", new[] { "GearTypeId" });
            DropIndex("dbo.BuyNows", new[] { "User_Id" });
            DropIndex("dbo.BuyNows", new[] { "VehicleId" });
            DropTable("dbo.RetailCustomers");
            DropTable("dbo.CorporateCustomers");
            DropTable("dbo.VehicleTramers");
            DropTable("dbo.VehicleStatusHistories");
            DropTable("dbo.VehicleStatus");
            DropTable("dbo.VehicleImages");
            DropTable("dbo.VehicleBoughtAndSolds");
            DropTable("dbo.Tramers");
            DropTable("dbo.TenderStatus");
            DropTable("dbo.Tenders");
            DropTable("dbo.TenderHistories");
            DropTable("dbo.Stocks");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.RetailVehiclePurchaseStatus");
            DropTable("dbo.RetailVehiclePurchases");
            DropTable("dbo.NotaryFees");
            DropTable("dbo.Messages");
            DropTable("dbo.Expertises");
            DropTable("dbo.CommissionFees");
            DropTable("dbo.ChatBotUserMessages");
            DropTable("dbo.ChatBots");
            DropTable("dbo.Models");
            DropTable("dbo.GearTypes");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.Colors");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.BuyNows");
            DropTable("dbo.Brands");
            DropTable("dbo.BodyTypes");
        }
    }
}
