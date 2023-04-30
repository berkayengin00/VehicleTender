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
using VehicleTender.Entity.Enum;
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
			ViewBag.UserTypeList = new TenderTypeDal().GetAllTenderTypes();
			if (HttpContext.Cache["vehicleFeatures"] == null)
			{
				result = new VehicleAddVMForAdmin()
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
		// todo bütün postlara validateantiforgerytoken ekle - yapıldı
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Add(DbVehicleAddVmForAdmin vm, List<HttpPostedFileBase> images)
		{
			List<string> imagePathList = new ImageAdd().AddImage(images);

			// todo vehicleage için view üzerinde ekleme yapılacak
			vm.CreatedBy = vm.UpdatedBy = GetUserId();
			//vm.UserId = GetUserId();
			var result = new VehicleDal().Add(vm, imagePathList);
			return RedirectToAction("GetAll");
		}

		public ActionResult GetAll()
		{
			var list = new VehicleDal().GetAllForAdmin();
			return View(list);
		}

		public ActionResult Update(int vehicleId)
		{

			var result = new VehicleDal().GetVehicleByVehicleId(vehicleId);
			if (!result.IsSuccess) return View("GetAll");

			result.Data.VehicleStatusList = new VehicleStatuDal().GetAllVehicleStatuses();
			result.Data.VehicleFeaturesForCache = GetFeaturesFromCache();

			return View(result.Data);
			// todo uyarı ver

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

			if (HttpContext.Cache["vehicleFeatures"] == null)
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

			return HttpContext.Cache["vehicleFeatures"] as VehicleFeaturesForCache;


		}

		public ActionResult GetUsersByUserType(int userTypeId)
		{

			return Json(userTypeId == (int)TenderOwnerType.Retired
				? new RetailCustomerDal().GetUsersForDropdown()
				: new CorporateCustomerDal().GetUsersForDropdown()
				, JsonRequestBehavior.AllowGet);

		}

		public ActionResult GetModelByBrand(int brandId)
		{
			var model = GetFeaturesFromCache().Models.FindAll(x => x.Value == brandId.ToString());
			return Json(model, JsonRequestBehavior.AllowGet);
		}
	}
}