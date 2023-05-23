using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View.Vehicle;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleDal : CrudRepository<Vehicle>
	{
		public VehicleDal() : base(new EfVehicleTenderContext())
		{

		}

		/// <summary>
		/// Aracı Ekler ve gerekli tablolara kayıt atar. Geriye Result döner.
		/// </summary>
		/// <param name="vm"></param>
		/// <param name="imageList"></param>
		/// <returns></returns>
		public Result Add(DbVehicleAddVmForAdmin vm, List<string> imageList)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (EfVehicleTenderContext db = new EfVehicleTenderContext())
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
							CreatedBy = vm.CreatedBy,
							CreatedDate = vm.CreatedDate,
							UpdatedBy = vm.UpdatedBy,
							UpdatedDate = vm.UpdatedDate,
							IsActive = vm.IsActive,
							ModelId = vm.ModelId,
							Version = vm.Version,
							KiloMeter = vm.KiloMeter,
							Description = vm.Description,
							VehicleYear = vm.VehicleYear,
							LicensePlate = vm.LicensePlate,
							UserId = vm.UserId,
						};
						int vehicleId = db.Vehicles.Add(vehicle).Id;

						db.VehiclePrices.Add(new VehiclePrice()
						{
							AddedDate = vm.CreatedDate,
							IsActive = vm.IsActive,
							VehicleId = vehicleId,
							Price = vm.VehiclePrice
						});

						// todo: buraya dön
						if (vm.UserTypeId != (int)UserTypeEnum.Retired)
						{
							db.Stocks.Add(new Stock()
							{
								UserId = vm.UserId,
								VehicleId = vehicleId,
								IsActive = true,
								UpdatedDate = DateTime.Now,
								AddedPrice = vm.VehiclePrice,
								CreatedBy = vm.UserId,
								CreatedDate = DateTime.Now,
								PreliminaryValuationPrice = vm.VehiclePrice,
								UpdatedBy = vm.UserId,
								UserTypeId = vm.UserTypeId

							});
						}

						db.VehicleStatusHistories.Add(new VehicleStatusHistory()
						{
							VehicleStatusId = (int)VehicleStatusType.Giris,
							IsActive = true,
							StatusChangeDate = DateTime.Now,
							VehicleId = vehicleId
						});

						//new VehicleStatusHistoryDal().Insert();

						if (imageList != null)
						{
							foreach (var item in imageList)
							{
								db.VehicleImages.Add(new VehicleImage()
								{
									ImagePath = item,
									IsActive = vm.IsActive,
									VehicleId = vehicleId
								});
							}

						}

						if (vm.TramerList != null)
						{
							foreach (var item in vm.TramerList)
							{
								db.VehicleTramers.Add(new VehicleTramer()
								{
									TramerId = item.TramerId,
									VehicleId = vehicleId,
									VehiclePartStatusId = item.VehiclePartId,
									PartPrice = item.PartPrice,
									AddedDate = item.AddDateTime,
								});
							}
						}

						var result = db.SaveChanges();
						tran.Complete();
						return new Result("Araç Eklendi", true);

					}
					catch (Exception exception)
					{
						// todo : loglama yapılacak

						tran.Dispose();
						return new Result("Araç Eklerken Hata Oluştu", false);
					}
				}

			}
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
						join bodyType in db.BodyTypes on vehicle.BodyTypeId equals bodyType.Id
						join color in db.Colors on vehicle.ColorId equals color.Id
						join user in db.Users on vehicle.CreatedBy equals user.Id
						where vehicle.IsActive
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

		public DataResult<VehicleUpdateVM> GetVehicleByVehicleId(int vehicleId)
		{
			VehicleUpdateVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from vehicle in db.Vehicles
						  where vehicle.Id == vehicleId && vehicle.IsActive
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
							  vehicleImages = db.VehicleImages.Where(x => x.VehicleId == vehicleId).Select(x => new VehicleImageVM() { VehicleId = x.VehicleId, ImagePath = x.ImagePath }).ToList(),
							  VehicleStatusId = (from vsh in db.VehicleStatusHistories
												 where vsh.VehicleId == vehicle.Id
												 join vehicleStatus in db.VehicleStatus on vsh.VehicleStatusId equals vehicleStatus.Id
												 orderby vsh.StatusChangeDate descending
												 select vehicleStatus.Id).FirstOrDefault(),
							  VehiclePrice = (from price in db.VehiclePrices where price.VehicleId == vehicleId orderby price.AddedDate descending select price.Price).FirstOrDefault()
						  }).SingleOrDefault();

			}
			return new DataResult<VehicleUpdateVM>(result != null ? "Data Geldi" : "Boş", result, result != null);
		}

		/// <summary>
		/// Aracı Günceller ve geriye Result döner
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		public Result Update(VehicleUpdateVM vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (EfVehicleTenderContext db = new EfVehicleTenderContext())
				{
					try
					{
						Vehicle vehicle = db.Vehicles.SingleOrDefault(x => x.Id == vm.VehicleId);
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

						db.VehiclePrices.Add(new VehiclePrice()
						{
							VehicleId = vm.VehicleId,
							Price = vm.VehiclePrice,
							AddedDate = vm.UpdatedDate,
						});

						VehicleStatusHistoryDal vshDal = new VehicleStatusHistoryDal();
						if (vshDal.CheckVehicleStatus(vm.VehicleId, vm.VehicleStatusId))
						{
							db.VehicleStatusHistories.Add(new VehicleStatusHistory()
							{
								VehicleId = vm.VehicleId,
								VehicleStatusId = vm.VehicleStatusId,
								StatusChangeDate = vm.StatusChangedDate
							});
						}

						int result = db.SaveChanges();
						tran.Complete();
						return new Result("Araç Güncellendi", true);

					}
					catch (Exception e)
					{
						tran.Dispose();
						return new Result("Araç Güncellenemedi", false);

					}
				}

			}
		}

		/// <summary>
		/// Aracın durumunu değiştirir ve Geriye Result döner
		/// </summary>
		/// <param name="vehicleId"></param>
		/// <returns></returns>
		public Result SoftDelete(int vehicleId)
		{
			var vehicle = Get(x => x.Id == vehicleId);
			vehicle.IsActive = false;
			var result= Save();
			return new Result(result > 0 ? "Silme İşlemi Başarılı" : "Hata", result > 0);
		}

		/// <summary>
		/// Şirkete Ait araçlar select list item olarak döner
		/// </summary>
		/// <returns></returns>
		public List<SelectListItem> GetAllVehicleByUserType(int userId)
		{
			List<SelectListItem> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from vehicle in db.Vehicles
						join vsh in db.VehicleStatusHistories on vehicle.Id equals vsh.VehicleId
						where vsh.StatusChangeDate == db.VehicleStatusHistories
							.Where(v => v.VehicleId == vehicle.Id)
							.Max(v => v.StatusChangeDate)
						orderby vsh.StatusChangeDate descending
						where vsh.VehicleStatusId != (int)VehicleStatusType.Ihalede && vehicle.UserId==userId && vehicle.IsActive
						select new SelectListItem()
						{
							Text = vehicle.LicensePlate,
							Value = vehicle.Id.ToString()
						}).ToList();
			}

			return list;
		}
	}
}
