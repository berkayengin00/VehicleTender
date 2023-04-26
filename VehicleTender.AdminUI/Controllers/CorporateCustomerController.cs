using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.CorporateCustomer;

namespace VehicleTender.AdminUI.Controllers
{
    public class CorporateCustomerController : Controller
    {
		// GET: CorporateCustomer
		public ActionResult GetAll()
		{
			List<CorporateCustomer> list = new CorporateCustomerDal().GetAll();
			return View(list);
		}

		public ActionResult Add()
		{
			return View(new CorporateCustomerAddVM());
		}

		[HttpPost,ValidateAntiForgeryToken]
		public ActionResult Add(CorporateCustomerAddVM vm)
		{
			vm.UpdatedBy = vm.CreatedBy = GetUserId();
			int result = new CorporateCustomerDal().Add(vm);
			ViewBag.Result = result > 0 ? "Kurumsal Müşteri Kaydedildi" : "Hata!!!";
			if (result>0)
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
				return View(result.Data);
			}
			return RedirectToAction("GetAll");
		}

		[HttpPost,ValidateAntiForgeryToken]
		public ActionResult Update(CorporateCustomerUpdateVM vm)
		{
			vm.UpdatedBy = GetUserId(); ;
			if (new CorporateCustomerDal().Update(vm))
			{
				return RedirectToAction("GetAll");
			}
			return View("Update");
		}

		public ActionResult SoftDelete(int userId)
		{
			new CorporateCustomerDal().SoftDelete(userId);
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
	}
}