using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Result;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleDal : CrudRepository<Vehicle>
	{
		public VehicleDal() : base(new EfVehicleTenderContext())
		{

		}

		public int Add(DbVehicleAddVmForAdmin vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				try
				{
					Vehicle vehicle = new Vehicle()
					{
						BodyTypeId = vm.BodyTypeId,
						ColorId = vm.ColorId,
						FuelTypeId = vm.FuelTypeId,
						GearTypeId = vm.GearTypeId,
						CreatedBy = 1,
						CreatedDate = DateTime.Now,
						UpdatedBy = 1,
						UpdatedDate = DateTime.Now,
						IsActive = true,
						ModelId = vm.ModelId,
						Version = vm.Version,
						KiloMeter = vm.KiloMeter,
						Description = vm.Description,
						VehicleAge = DateTime.Now.Date,
					};
					base.Insert(vehicle);
					int vehicleId = vehicle.Id;

					new StockDal().Insert(new Stock()
					{
						UserId = vm.UserId,
						VehicleId = vehicleId,
						IsActive = true,
						UpdatedDate = DateTime.Now,
						AddedPrice = 10000,
						CreatedBy = vm.UserId,
						CreatedDate = DateTime.Now,
						PreliminaryValuationPrice = 10000,
						UpdatedBy = vm.UserId
					});
					new VehicleStatusHistoryDal().Insert(new VehicleStatusHistory()
					{
						VehicleStatusId = Convert.ToInt16(VehicleStatusType.Giris),
						IsActive = true,
						StatusChangeDate = DateTime.Now,
						VehicleId = vehicleId
					});

					new VehicleStatusHistoryDal().Save();
					tran.Complete();
				}
				catch(Exception exception)
				{
					tran.Dispose();
				}

			}

			return 0;
		}

		public List<VehicleVMForAdmin> GetAllForAdmin()
		{
			List<VehicleVMForAdmin> list = null;
			using (EfVehicleTenderContext db =new EfVehicleTenderContext())
			{
				list = (from vehicle in db.Vehicles
					join model in db.Models on vehicle.ModelId equals model.Id
					join brand in db.Brands on model.BrandId equals brand.Id
					join gearType in db.GearTypes on vehicle.GearTypeId equals gearType.Id
					join fuelType in db.FuelTypes on vehicle.FuelTypeId equals fuelType.Id
					join bodyType in db.FuelTypes on vehicle.BodyTypeId equals bodyType.Id
					join color in db.Colors on vehicle.ColorId equals color.Id
					join user in db.Users on vehicle.CreatedBy equals user.Id
					//join vsh in db.VehicleStatusHistories on vehicle.Id equals vsh.Id orderby vsh.StatusChangeDate descending
					//join vs  in db.VehicleStatus on vsh.VehicleStatusId equals vs.Id
					select new VehicleVMForAdmin()
					{
						VehicleId = vehicle.Id,
						Model = model.ModelName,
						Brand = brand.BrandName,
						Version = vehicle.Version,
						KiloMeter = vehicle.KiloMeter,
						Description = vehicle.Description,
						BodyType = bodyType.Name,
						Color = color.Name,
						EmailOfTheAdder = user.Email,
						FuelType = fuelType.Name,
						GearType = gearType.Name,
						//StatusName = vs.StatusName
						StatusName = (from vsh in db.VehicleStatusHistories
									  where vsh.VehicleId == vehicle.Id
									  join vehicleStatus in db.VehicleStatus on vsh.VehicleStatusId equals vehicleStatus.Id
									  orderby vsh.StatusChangeDate descending
									  select vehicleStatus.StatusName).FirstOrDefault()
					}).ToList();
			}

			return list;
		}
	}
}
