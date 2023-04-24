using System.Data.Entity;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
    public class EfVehicleTenderContext:DbContext
    {
	    public EfVehicleTenderContext():base("connection")
	    {
            base.Configuration.LazyLoadingEnabled = false;
	    }
        public DbSet<User> Users { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BuyNow> BuyNows { get; set; }
        public DbSet<ChatBot> ChatBots { get; set; }
        public DbSet<ChatBotUserMessage> ChatBotUserMessages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CommissionFee> CommissionFees { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<NotaryFee> NotaryFees { get; set; }
        public DbSet<RetailCustomer> RetailCustomers { get; set; }
        public DbSet<RetailVehiclePurchase> RetailVehiclePurchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderHistory> TenderHistories { get; set; }
        public DbSet<TenderStatus> TenderStatus{ get; set; }
        public DbSet<TenderType> TenderTypes { get; set; }
        public DbSet<TenderDetail> TenderDetails { get; set; }
        public DbSet<Tramer> Tramers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBoughtAndSold> VehicleBoughtAndSolds { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<VehicleStatusHistory> VehicleStatusHistories { get; set; }
        public DbSet<VehicleTramer> VehicleTramers { get; set; }
        public DbSet<LogType> LogTypes { get; set; } 
        public DbSet<LogDetail> LogDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Entity<RoleUser>()
				.HasKey(x => new { x.RoleId, x.UserId });

			modelBuilder.Entity<VehicleTramer>()
				.HasKey(x => new { x.VehicleId, x.TramerId });

			modelBuilder.Entity<TenderHistory>()
				.HasRequired(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.WillCascadeOnDelete();
			modelBuilder.Entity<TenderHistory>()
				.HasRequired(x => x.Tender)
				.WithMany()
				.HasForeignKey(x => x.TenderId)
				.WillCascadeOnDelete();

			modelBuilder.Entity<RetailCustomer>().ToTable("RetailCustomers");
			modelBuilder.Entity<CorporateCustomer>().ToTable("CorporateCustomers");
			modelBuilder.Entity<Vehicle>().Property(x => x.LicensePlate).IsRequired();
        }

    }
}
