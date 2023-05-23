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

		[HttpGet]
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
			if (!ModelState.IsValid)
			{
				vm.CacheList = CheckCache();
				return View(vm);
			}

			vm.UpdatedBy = vm.CreatedBy = GetUserId();
			var result = new CorporateCustomerDal().Add(vm);
			TempData.Add("message", result);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}

			return RedirectToAction("Add");

		}

		[HttpGet]
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
			vm.UpdatedBy = GetUserId();
			var result = new CorporateCustomerDal().Update(vm);
			TempData.Add("message", result);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}
			return View("Update");
		}

		[HttpGet]
		public ActionResult UpdateIsVerify(int id)
		{
			var result =new CorporateCustomerDal().UpdateIsVerify(id);
			TempData.Add("message", result);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}
			return RedirectToAction("Page404","MyError");
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
			var result = new CorporateCustomerDal().UpdatePackage(userId, id);
			TempData.Add("message", result);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}
			return RedirectToAction("Page404","MyError");
		}

		[HttpGet]
		public ActionResult SoftDelete(int userId)
		{
			var result = new CorporateCustomerDal().SoftDelete(userId);
			TempData.Add("message", result);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}
			return RedirectToAction("Page404", "MyError");
		}


		public ActionResult GetDistrictByProvince(int provinceId)
		{
			var result = CheckCache().DistrictList.FindAll(x => x.ProvinceId == provinceId);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// İlleri ve İlçeleri Cacheden Getirir Eğer Yoksa Veritabanından Çeker ve Cache'e Ekler
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Sessionda kayıtlı olan tramer bilgilerini döndürür.
		/// </summary>
		/// <returns></returns>
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