using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View;
using System.Web.Caching;
using VehicleTender.DAL.FileAdd;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View.Vehicle;
using VehicleTender.Entity.View.Tramer;

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

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Add(DbVehicleAddVmForAdmin vm, List<HttpPostedFileBase> images)
		{
			// todo image ekleme yapılacak
			List<string> imagePathList = new ImageAdd().AddImage(images);
			
			// sessiondan alınacak
			vm.TramerList = CheckSession();

			vm.CreatedBy = vm.UpdatedBy = GetUserId();
			var result = new VehicleDal().Add(vm, imagePathList);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}

			return View();

		}

		public ActionResult GetAll()
		{
			var list = new VehicleDal().GetAllForAdmin();
			return View(list);
		}

		public ActionResult Update(int vehicleId)
		{

			var result = new VehicleDal().GetVehicleByVehicleId(vehicleId);
			if (!result.IsSuccess) return RedirectToAction("Page404","MyError");

			result.Data.VehicleStatusList = new VehicleStatuDal().GetAllVehicleStatuses();
			result.Data.VehicleFeaturesForCache = GetFeaturesFromCache();

			return View(result.Data);
			// todo uyarı ver

		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Update(VehicleUpdateVM vm)
		{
			vm.UpdatedBy = GetUserId();
			return new VehicleDal().Update(vm).IsSuccess 
				? RedirectToAction("GetAll") : RedirectToAction("Page404","MyError");
		}

		[HttpGet]
		public ActionResult SoftDelete(int vehicleId)
		{
			var result = new VehicleDal().SoftDelete(vehicleId);
			return !result.IsSuccess ? 
				RedirectToAction("Page500","MyError") : 
				RedirectToAction("GetAll");
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

		[NonAction]
		public VehicleFeaturesForCache GetFeaturesFromCache()
		{
			if (HttpContext.Cache["vehicleFeatures"] != null)
				return HttpContext.Cache["vehicleFeatures"] as VehicleFeaturesForCache;
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
		[HttpGet]
		public ActionResult GetUsersByUserType(int userTypeId)
		{

			return Json(userTypeId == (int)UserTypeEnum.Retired
				? new RetailCustomerDal().GetUsersForDropdown().Data
				: new CorporateCustomerDal().GetUsersForDropdown()
				, JsonRequestBehavior.AllowGet);

		}

		[HttpGet]
		public ActionResult GetModelByBrand(int brandId)
		{
			var model = GetFeaturesFromCache().Models.FindAll(x => x.Value == brandId.ToString());
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		[NonAction]
		public List<TramerAddVM> CheckSession()
		{
			if (Session["Tramer"] == null)
			{
				return null;
			}
			var result = Session["Tramer"] as List<TramerAddVM>;
			Session.Remove("Tramer");
			return result;
		}

	}
}