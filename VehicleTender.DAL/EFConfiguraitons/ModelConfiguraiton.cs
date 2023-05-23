using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.EFConfiguraitons
{
	public class ModelConfiguration : EntityTypeConfiguration<Model>
	{
		public ModelConfiguration()
		{
			ToTable("Model");
			HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.ModelName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class BodyTypeConfiguration : EntityTypeConfiguration<BodyType>
	{
		public BodyTypeConfiguration()
		{
			ToTable("BodyType");
			HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class BrandConfiguration : EntityTypeConfiguration<Brand>
	{
		public BrandConfiguration()
		{
			ToTable("Brand");
			HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.BrandName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class BuyNowConfiguration : EntityTypeConfiguration<BuyNow>
	{
		public BuyNowConfiguration()
		{
			ToTable("BuyNow");
			HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Price).HasPrecision(18, 2);
			Property(x => x.IsActive).IsRequired();
			Property(x => x.AdvertDescription).HasMaxLength(200).IsRequired();
			Property(x => x.AdvertName).HasMaxLength(100).IsRequired();
			// belirtilmeyen alanlar için default olarak required olarak ayarlanmıştır.

		}
	}

	public class ChatBotConfiguration : EntityTypeConfiguration<ChatBot>
	{
		public ChatBotConfiguration()
		{
			ToTable("ChatBot");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Message).HasMaxLength(150).IsRequired();
			Property(x => x.AltMessage); // todo
		}
	}


	public class ChatBotUserConfiguration : EntityTypeConfiguration<ChatBotUserMessage>
	{
		public ChatBotUserConfiguration()
		{
			ToTable("ChatBotUser");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.MessageContent).HasMaxLength(150).IsRequired();

		}
	}

	public class ColorConfiguration : EntityTypeConfiguration<Color>
	{
		public ColorConfiguration()
		{
			ToTable("Color");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();

		}
	}


	public class CommissionFeeConfiguration : EntityTypeConfiguration<CommissionFee>
	{
		public CommissionFeeConfiguration()
		{
			ToTable("CommissionFee");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.VehicleMinPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.VehicleMaxPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class CorporateCustomerConfiguration : EntityTypeConfiguration<CorporateCustomer>
	{
		public CorporateCustomerConfiguration()
		{
			ToTable("CorporateCustomer");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.CompanyName).HasMaxLength(100).IsRequired();
			Property(x => x.DistrictId).IsRequired();
			Property(x => x.CompanyType).HasMaxLength(100).IsRequired();
			Property(x => x.FirstName).HasMaxLength(100).IsRequired();
			Property(x => x.LastName).HasMaxLength(100).IsRequired();
			Property(x => x.Neighbourhood).HasMaxLength(250).IsRequired();
			Property(x => x.PhoneNumber).HasMaxLength(11).IsFixedLength().IsRequired();
			Property(x => x.IsActive).IsRequired();

		}
	}


	public class CorporatePackageConfiguration : EntityTypeConfiguration<CorporatePackage>
	{
		// todo müşterilen tanımlı olduğu paketleride tutmak için ayrı bir tablo oluşturulacak
		public CorporatePackageConfiguration()
		{
			ToTable("CorporatePackage");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.PackageName).HasMaxLength(100).IsRequired();
		}
	}

	public class ExpertiseConfiguration : EntityTypeConfiguration<Expertise>
	{
		public ExpertiseConfiguration()
		{
			ToTable("Expertise");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.Address).HasMaxLength(300).IsRequired();
		}
	}

	public class FuelTypeConfiguration : EntityTypeConfiguration<FuelType>
	{
		public FuelTypeConfiguration()
		{
			ToTable("FuelType");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}


	public class GearTypeConfiguration : EntityTypeConfiguration<GearType>
	{
		public GearTypeConfiguration()
		{
			ToTable("GearType");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}

	public class LogDetailConfiguration : EntityTypeConfiguration<LogDetail>
	{
		public LogDetailConfiguration()
		{
			ToTable("LogDetail");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Description).HasMaxLength(500).IsRequired();
		}
	}

	public class LogTypeConfiguration : EntityTypeConfiguration<LogType>
	{
		public LogTypeConfiguration()
		{
			ToTable("LogType");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}


	public class MessageConfiguration : EntityTypeConfiguration<Message>
	{
		public MessageConfiguration()
		{
			ToTable("Message");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Content).HasMaxLength(1000).IsRequired();
		}
	}

	public class NotaryFeeConfiguration : EntityTypeConfiguration<NotaryFee>
	{
		public NotaryFeeConfiguration()
		{
			ToTable("NotaryFee");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Fee).HasPrecision(18, 2).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class RetailCustomerConfiguration : EntityTypeConfiguration<RetailCustomer>
	{
		public RetailCustomerConfiguration()
		{
			ToTable("RetailCustomer");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.FirstName).HasMaxLength(100).IsRequired();
			Property(x => x.LastName).HasMaxLength(100).IsRequired();
			// phonenumber min 11 ve max 11 olmalı
			Property(x => x.PhoneNumber).HasMaxLength(11).IsFixedLength().IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class RetailVehiclePurchaseConfiguration : EntityTypeConfiguration<RetailVehiclePurchase>
	{
		public RetailVehiclePurchaseConfiguration()
		{
			ToTable("RetailVehiclePurchase");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.PreliminaryValuationPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.QuotedPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.RetailVehiclePurchaseStatusId).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class RetailVehiclePurchaseStatusConfiguration : EntityTypeConfiguration<RetailVehiclePurchaseStatus>
	{
		public RetailVehiclePurchaseStatusConfiguration()
		{
			ToTable("RetailVehiclePurchaseStatus");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class RoleConfiguration : EntityTypeConfiguration<Role>
	{
		public RoleConfiguration()
		{
			ToTable("Role");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.RoleName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class RoleUserConfiguration : EntityTypeConfiguration<RoleUser>
	{
		public RoleUserConfiguration()
		{
			// todo ara tablo buna geri dön
			ToTable("RoleUser");
			HasKey(x => new { x.RoleId, x.UserId });
		}
	}

	public class StockConfiguration : EntityTypeConfiguration<Stock>
	{
		public StockConfiguration()
		{
			ToTable("Stock");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.PreliminaryValuationPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.AddedPrice).HasPrecision(18, 2).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class TenderConfiguration : EntityTypeConfiguration<Tender>
	{
		public TenderConfiguration()
		{
			ToTable("Tender");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.TenderName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class TenderDetailConfiguration : EntityTypeConfiguration<TenderDetail>
	{
		public TenderDetailConfiguration()
		{
			// todo bu ara tablo olacak sonra geri dön
			ToTable("TenderDetail");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.IsActive).IsRequired();

		}
	}

	public class TenderHistoryConfiguration : EntityTypeConfiguration<TenderHistory>
	{
		public TenderHistoryConfiguration()
		{
			ToTable("TenderHistory");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Price).HasPrecision(18, 2).IsRequired();
			Property(x => x.IsActive).IsRequired();


			HasRequired(x => x.User)
			.WithMany()
			.HasForeignKey(x => x.UserId)
			.WillCascadeOnDelete();

			//HasRequired(x => x.TenderDetail)
			//    .WithMany()
			//    .HasForeignKey(x => x.TenderDetailId)
			//    .WillCascadeOnDelete(true);
		}
	}

	public class UserTypeConfiguration : EntityTypeConfiguration<UserType>
	{
		public UserTypeConfiguration()
		{
			ToTable("UserType");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class TramerConfiguration : EntityTypeConfiguration<Tramer>
	{
		public TramerConfiguration()
		{
			ToTable("Tramer");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.TramerName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("User");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Email).HasMaxLength(256).IsRequired();
			Property(x => x.PasswordHash).HasMaxLength(300).IsRequired();
			Property(x => x.IsActive).IsRequired();

			HasMany(x => x.Vehicles)
				.WithRequired(x => x.User)
				.HasForeignKey(x => x.UserId)
				.WillCascadeOnDelete(false);

		}
	}

	public class VehicleBoughtAndSoldConfiguration : EntityTypeConfiguration<VehicleBoughtAndSold>
	{
		public VehicleBoughtAndSoldConfiguration()
		{
			ToTable("VehicleBoughtAndSold");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Price).HasPrecision(18, 2).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class VehicleImageConfiguration : EntityTypeConfiguration<VehicleImage>
	{
		public VehicleImageConfiguration()
		{
			ToTable("VehicleImage");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class VehicleStatusConfiguration : EntityTypeConfiguration<VehicleStatus>
	{
		public VehicleStatusConfiguration()
		{
			ToTable("VehicleStatus");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.StatusName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class VehicleStatusHistoryConfiguration : EntityTypeConfiguration<VehicleStatusHistory>
	{
		public VehicleStatusHistoryConfiguration()
		{
			ToTable("VehicleStatusHistory");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.IsActive).IsRequired();
		}
	}


	public class VehicleTramerConfiguration : EntityTypeConfiguration<VehicleTramer>
	{
		public VehicleTramerConfiguration()
		{

			ToTable("VehicleTramer");
			HasKey(x => new { x.VehicleId, x.TramerId, x.VehiclePartStatusId });
		}
	}


	public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
	{
		public VehicleConfiguration()
		{
			ToTable("Vehicle");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Description).HasMaxLength(100).IsRequired();
			Property(x => x.LicensePlate).HasMaxLength(15).IsRequired();
			Property(x => x.Version).HasMaxLength(15).IsRequired();


			//HasOptional(x=>x.User)
			//	.WithMany()
			//	.WillCascadeOnDelete();
		}
	}


	public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
	{
		public EmployeeConfiguration()
		{
			ToTable("Employee");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.FirstName).HasMaxLength(100).IsRequired();
			Property(x => x.LastName).HasMaxLength(100).IsRequired();
			Property(x => x.UserName).HasMaxLength(100).IsRequired();
			Property(x => x.IsActive).IsRequired();
		}
	}

	public class MenuRoleConfiguration : EntityTypeConfiguration<RoleMenu>
	{
		public MenuRoleConfiguration()
		{
			ToTable("RoleMenu");
			HasKey(x => new { x.RoleId, x.MenuId });
		}
	}

	public class MenuConfiguration : EntityTypeConfiguration<Menu>
	{
		public MenuConfiguration()
		{
			ToTable("Menu");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
			Property(x => x.Url).HasMaxLength(200).IsRequired();
		}
	}

	public class VehiclePriceConfiguration : EntityTypeConfiguration<VehiclePrice>
	{
		public VehiclePriceConfiguration()
		{
			ToTable("VehiclePrice");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}


	public class VehiclePartStatusConfiguration : EntityTypeConfiguration<VehiclePartStatus>
	{
		public VehiclePartStatusConfiguration()
		{
			ToTable("VehiclePartStatus");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(150).IsRequired();
		}
	}

	public class ProvinceConfiguration : EntityTypeConfiguration<Province>
	{
		public ProvinceConfiguration()
		{
			ToTable("Province");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}

	public class DistrictConfiguration : EntityTypeConfiguration<District>
	{
		public DistrictConfiguration()
		{
			ToTable("District");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Name).HasMaxLength(100).IsRequired();
		}
	}

	public class FinishedTenderConfiguration : EntityTypeConfiguration<FinishedTender>
	{
		public FinishedTenderConfiguration()
		{
			ToTable("FinishedTender");
			HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}


}
