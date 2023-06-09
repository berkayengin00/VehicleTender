﻿using System;
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
using VehicleTender.Entity.View.RetailCustomer;
using VehicleTender.Entity.View.Vehicle;

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
					// todo : dateler güncellenecek
					Vehicle vehicle = new Vehicle()
					{
						BodyTypeId = vm.BodyTypeId,
						ColorId = vm.ColorId,
						FuelTypeId = vm.FuelTypeId,
						GearTypeId = vm.GearTypeId,
						CreatedBy = 1,
						CreatedDate = vm.CreatedDate,
						UpdatedBy = 1,
						UpdatedDate = vm.UpdatedDate,
						IsActive = vm.IsActive,
						ModelId = vm.ModelId,
						Version = vm.Version,
						KiloMeter = vm.KiloMeter,
						Description = vm.Description,
						VehicleYear = vm.VehicleYear,
						LicensePlate = vm.LicensePlate,
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
						UpdatedBy = vm.UserId,
						
					});
					new VehicleStatusHistoryDal().Insert(new VehicleStatusHistory()
					{
						VehicleStatusId = Convert.ToInt16(VehicleStatusType.Giris),
						IsActive = true,
						StatusChangeDate = DateTime.Now,
						VehicleId = vehicleId
					});

					Save();
					tran.Complete();
				}
				catch (Exception exception)
				{
					tran.Dispose();
				}

			}

			return 0;
		}

		public List<VehicleVMForAdmin> GetAllForAdmin()
		{
			List<VehicleVMForAdmin> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				// todo group by bakılacak
				list = (from vehicle in db.Vehicles
						join model in db.Models on vehicle.ModelId equals model.Id
						join brand in db.Brands on model.BrandId equals brand.Id
						join gearType in db.GearTypes on vehicle.GearTypeId equals gearType.Id
						join fuelType in db.FuelTypes on vehicle.FuelTypeId equals fuelType.Id
						join bodyType in db.FuelTypes on vehicle.BodyTypeId equals bodyType.Id
						join color in db.Colors on vehicle.ColorId equals color.Id
						join user in db.Users on vehicle.CreatedBy equals user.Id
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
							IsActive = vehicle.IsActive,
							LicencePlate = vehicle.LicensePlate,
							StatusName = (from vsh in db.VehicleStatusHistories
										  where vsh.VehicleId == vehicle.Id
										  join vehicleStatus in db.VehicleStatus on vsh.VehicleStatusId equals vehicleStatus.Id
										  orderby vsh.StatusChangeDate descending
										  select vehicleStatus.StatusName).FirstOrDefault()
						}).ToList();
			}

			return list;
		}

		public Result<VehicleUpdateVM> GetVehicleByVehicleId(int vehicleId)
		{
			VehicleUpdateVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from vehicle in db.Vehicles
						  where vehicle.Id == vehicleId
						  select new VehicleUpdateVM()
						  {
							  ModelId = vehicle.ModelId,
							  BodyTypeId = vehicle.BodyTypeId,
							  ColorId = vehicle.ColorId,
							  FuelTypeId = vehicle.FuelTypeId,
							  GearTypeId = vehicle.GearTypeId,
							  Version = vehicle.Version,
							  KiloMeter = vehicle.KiloMeter,
							  Description = vehicle.Description,
							  BrandId = vehicle.Model.BrandId,
							  LicensePlate = vehicle.LicensePlate,
							  VehicleId = vehicle.Id,
							  VehicleYear = vehicle.VehicleYear,
							  VehicleStatusId = (from vsh in db.VehicleStatusHistories
												 where vsh.VehicleId == vehicle.Id
												 join vehicleStatus in db.VehicleStatus on vsh.VehicleStatusId equals vehicleStatus.Id
												 orderby vsh.StatusChangeDate descending
												 select vehicleStatus.Id).FirstOrDefault()
						  }).SingleOrDefault();

			}
			return new Result<VehicleUpdateVM>(result != null ? "Data Geldi" : "Boş", result, result != null);
		}

		public bool Update(VehicleUpdateVM vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				try
				{
					Vehicle vehicle = Get(x => x.Id == vm.VehicleId);
					if (vehicle != null)
					{
						vehicle.BodyTypeId = vm.BodyTypeId;
						vehicle.ColorId = vm.ColorId;
						vehicle.FuelTypeId = vm.FuelTypeId;
						vehicle.GearTypeId = vm.GearTypeId;
						vehicle.ModelId = vm.ModelId;
						vehicle.Version = vm.Version;
						vehicle.KiloMeter = vm.KiloMeter;
						vehicle.Description = vm.Description;
						vehicle.LicensePlate = vm.LicensePlate;
						vehicle.UpdatedDate = vm.UpdatedDate;
						vehicle.UpdatedBy = vm.UpdatedBy;
						vehicle.VehicleYear = vm.VehicleYear;

					}
					VehicleStatusHistoryDal vshDal = new VehicleStatusHistoryDal();
					if (vshDal.CheckVehicleStatus(vm.VehicleId, vm.VehicleStatusId))
					{
						vshDal.Insert(new VehicleStatusHistory()
						{
							VehicleId = vm.VehicleId,
							VehicleStatusId = vm.VehicleStatusId,
							StatusChangeDate = vm.StatusChangedDate
						});
					}
					tran.Complete();
				}
				catch (Exception e)
				{
					tran.Dispose();
					Console.WriteLine(e);
					throw;
				}
			}
			return Save() > 0;
		}

		public int SoftDelete(int vehicleId)
		{
			Vehicle vehicle = Get(x => x.Id == vehicleId);
			vehicle.IsActive = false;
			return Save();
		}
	}
}
