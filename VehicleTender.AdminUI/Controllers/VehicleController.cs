using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Caching;
using VehicleTender.DAL.FileAdd;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Vehicle;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
	public class VehicleController : Controller
	{
		// GET: Vehicle
		public ActionResult Add()
		{
			VehicleAddVMForAdmin result = null;
			if (HttpContext.Cache["vehicleFeatures"] ==null)
			{
				result  = new VehicleAddVMForAdmin()
				{
					VehicleFeaturesForCache = GetFeaturesFromCache()
				};
			}
			else
			{
				result = new VehicleAddVMForAdmin()
				{
					VehicleFeaturesForCache = HttpContext.Cache["vehicleFeatures"] as VehicleFeaturesForCache
				};
			}
			return View(result);
		}
		// todo bütün postlara validateantiforgerytoken ekle
		[HttpPost]
		public ActionResult Add(DbVehicleAddVmForAdmin vm,List<HttpPostedFileBase> Images)
		{
			new ImageAdd().AddImage(Images);
			
			// todo vehicleage için view üzerinde ekleme yapılacak
			vm.CreatedBy = vm.UpdatedBy = GetUserId();
			vm.UserId = GetUserId();
			var result = new VehicleDal().Add(vm);
			return RedirectToAction("GetAll");
		}

		public ActionResult GetAll()
		{
			var list = new VehicleDal().GetAllForAdmin();
			return View(list);
		}

		public ActionResult	Update(int vehicleId)
		{

			var result = new VehicleDal().GetVehicleByVehicleId(vehicleId);
			result.Data.VehicleStatusList = new VehicleStatuDal().GetAllVehicleStatuses();
			if (result.IsSuccess && HttpContext.Cache["vehicleFeatures"] == null)
			{
				result.Data.VehicleFeaturesForCache = GetFeaturesFromCache();
				return View(result.Data);
			}
			if (result.IsSuccess && HttpContext.Cache["vehicleFeatures"] != null)
			{
				result.Data.VehicleFeaturesForCache = HttpContext.Cache["vehicleFeatures"] as VehicleFeaturesForCache;
				return View(result.Data);
			}
			return RedirectToAction("GetAll");
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Update(VehicleUpdateVM vm)
		{
			vm.UpdatedBy = GetUserId();
			if (new VehicleDal().Update(vm))
			{
				return RedirectToAction("GetAll");
			}
			return View("Update");
		}

		public ActionResult SoftDelete(int vehicleId)
		{
			int result = new VehicleDal().SoftDelete(vehicleId);
			return RedirectToAction("GetAll");
		}

		/// <summary>
		///	Sistemde kayıtlı olan adminin id'sini döndürür.
		/// </summary>
		/// <returns></returns>
		[NonAction]
		public int GetUserId()
		{
			return Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}


		public VehicleFeaturesForCache GetFeaturesFromCache()
		{
			var result = new VehicleFeaturesForCache()
			{
				Brands = new BrandDal().GetAllBrand(),
				BodyTypes = new BodyTypeDal().GetAllBodyTypes(),
				Colors = new ColorDal().GetAllColors(),
				FuelTypes = new FuelDal().GetAllFuelTypes(),
				GearTypes = new GearTypeDal().GetAllGearTypes(),
				Models = new ModelDal().GetAllModels(),
			};
			HttpContext.Cache.Insert("vehicleFeatures", result, null, Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
			return result;
		}
	}
}