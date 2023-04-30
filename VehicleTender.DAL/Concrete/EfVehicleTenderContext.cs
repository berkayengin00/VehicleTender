using System.ComponentModel;
using System.Data.Entity;
using VehicleTender.DAL.EFConfiguraitons;
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
        public DbSet<CorporatePackage> CorporatePackages { get; set; }
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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<VehiclePrice> VehiclePrices { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

	        modelBuilder.Configurations.Add( new ModelConfiguration());
            modelBuilder.Configurations.Add( new UserConfiguration());
            modelBuilder.Configurations.Add( new BodyTypeConfiguration());
            modelBuilder.Configurations.Add( new BrandConfiguration());
            modelBuilder.Configurations.Add( new BuyNowConfiguration());
            modelBuilder.Configurations.Add( new ChatBotConfiguration());
            modelBuilder.Configurations.Add( new ChatBotUserConfiguration());
            modelBuilder.Configurations.Add( new CorporatePackageConfiguration());
            modelBuilder.Configurations.Add( new ColorConfiguration());
            modelBuilder.Configurations.Add( new RetailVehiclePurchaseStatusConfiguration());
            modelBuilder.Configurations.Add( new CommissionFeeConfiguration());
            modelBuilder.Configurations.Add( new CorporateCustomerConfiguration());
	        modelBuilder.Configurations.Add( new ExpertiseConfiguration());
	        modelBuilder.Configurations.Add( new FuelTypeConfiguration());
            modelBuilder.Configurations.Add( new GearTypeConfiguration());
            modelBuilder.Configurations.Add( new MessageConfiguration());
            modelBuilder.Configurations.Add( new NotaryFeeConfiguration());
            modelBuilder.Configurations.Add( new RetailCustomerConfiguration());
            modelBuilder.Configurations.Add( new RetailVehiclePurchaseConfiguration());
            modelBuilder.Configurations.Add( new RoleConfiguration());
            modelBuilder.Configurations.Add( new RoleUserConfiguration());
            modelBuilder.Configurations.Add( new StockConfiguration());
            modelBuilder.Configurations.Add( new TenderConfiguration());
            modelBuilder.Configurations.Add( new TenderHistoryConfiguration());
            modelBuilder.Configurations.Add( new TenderTypeConfiguration());
            modelBuilder.Configurations.Add( new TenderDetailConfiguration());
            modelBuilder.Configurations.Add( new TramerConfiguration());
            modelBuilder.Configurations.Add( new VehicleConfiguration());
            modelBuilder.Configurations.Add( new VehicleBoughtAndSoldConfiguration());
            modelBuilder.Configurations.Add( new VehicleImageConfiguration());
            modelBuilder.Configurations.Add( new VehicleStatusConfiguration());
            modelBuilder.Configurations.Add( new VehicleStatusHistoryConfiguration());
            modelBuilder.Configurations.Add( new VehicleTramerConfiguration());
            modelBuilder.Configurations.Add( new LogTypeConfiguration());
            modelBuilder.Configurations.Add( new LogDetailConfiguration());
            modelBuilder.Configurations.Add( new EmployeeConfiguration());
            modelBuilder.Configurations.Add( new MenuRoleConfiguration());
            modelBuilder.Configurations.Add( new MenuConfiguration());
            modelBuilder.Configurations.Add( new VehiclePriceConfiguration());
        }
    }
}
