using System;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.CorporateCustomer;
using VehicleTender.Entity.View.Tramer;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
	public class CorporateCustomerController : Controller
	{

		// GET: CorporateCustomer
		public ActionResult GetAll()
		{
			return View(new CorporateCustomerDal().GetAllForAdmin());
		}

		public ActionResult Add()
		{
			var result = new CorporateCustomerAddVM()
			{
				CacheList = CheckCache()
			};
			return View(result);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Add(CorporateCustomerAddVM vm)
		{
			vm.UpdatedBy = vm.CreatedBy = GetUserId();
			int result = new CorporateCustomerDal().Add(vm);
			ViewBag.Result = result > 0 ? "Kurumsal Müşteri Kaydedildi" : "Hata!!!";
			if (result > 0)
			{
				return RedirectToAction("GetAll");
			}
			return View("Add");

		}


		public ActionResult Update(int userId)
		{
			var result = new CorporateCustomerDal().GetUserByUserId(userId);
			if (result.IsSuccess)
			{
				result.Data.ListCache = CheckCache();
				return View(result.Data);
			}
			return RedirectToAction("GetAll");
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Update(CorporateCustomerUpdateVM vm)
		{
			vm.UpdatedBy = GetUserId(); ;
			if (new CorporateCustomerDal().Update(vm))
			{
				return RedirectToAction("GetAll");
			}
			return View("Update");
		}

		public ActionResult UpdateIsVerify(int id)
		{
			new CorporateCustomerDal().UpdateIsVerify(id);
			return RedirectToAction("GetAll");
		}


		[HttpGet]
		public ActionResult GetAllPackage(int userId)
		{
			ViewBag.UserId = userId;
			return Json(new CorporatePackageDal().GetAll(), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult UpdatePackage(int id, int userId)
		{
			new CorporateCustomerDal().UpdatePackage(userId, id);
			return RedirectToAction("GetAll");
		}

		public ActionResult SoftDelete(int userId)
		{
			new CorporateCustomerDal().SoftDelete(userId);
			return RedirectToAction("GetAll");
		}


		public ActionResult GetDistrictByProvince(int provinceId)
		{
			var result = CheckCache().DistrictList.FindAll(x => x.ProvinceId == provinceId);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ProvinceAndDistrictForCache CheckCache()
		{
			if (HttpContext.Cache["provinceAndDistrict"] == null)
			{
				ProvinceAndDistrictForCache result = new ProvinceAndDistrictForCache()
				{
					ProvinceList = new ProvinceDal().GetAll(),
					DistrictList = new DistrictDal().GetAll(),
				};
				HttpContext.Cache.Insert("provinceAndDistrict", result, null, Cache.NoAbsoluteExpiration,
					TimeSpan.FromDays(1));
			}
			return HttpContext.Cache["provinceAndDistrict"] as ProvinceAndDistrictForCache;

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
		public List<TramerAddVM> CheckSession()
		{
			if (Session["Tramer"] == null)
			{
				return null;
			}
			return Session["Tramer"] as List<TramerAddVM>;
		}
	}
}