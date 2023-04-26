using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.RetailCustomer;

namespace VehicleTender.AdminUI.Controllers
{
    public class RetailCustomerController : Controller
    {
		// GET: RetailCustomer
		public ActionResult Add()
		{
			return View(new RetailCustomerAddVM());
		}

		[HttpPost,ValidateAntiForgeryToken]
		public ActionResult Add(RetailCustomerAddVM vm)
		{
			vm.UpdatedBy = vm.CreatedBy = GetUserId();
			int result = new RetailCustomerDal().Add(vm);
			return RedirectToAction("GetAll");
		}

		public ActionResult GetAll()
		{
			List<RetailCustomer> list = new RetailCustomerDal().GetAll();
			return View(list);
		}
		[HttpGet]
		public ActionResult Update(int userId)
		{
			var result = new RetailCustomerDal().GetUserByUserId(userId);
			if (result.IsSuccess)
			{
				return View(result.Data);
			}
			return RedirectToAction("GetAll");
		}

		[HttpPost,ValidateAntiForgeryToken]
		public ActionResult Update(RetailCustomerUpdateVM vm)
		{
			vm.UpdatedBy = GetUserId();
			var result = new RetailCustomerDal().Update(vm);
			return RedirectToAction("GetAll");
		}

		public ActionResult	SoftDelete(int userId){
			var result = new RetailCustomerDal().SoftDelete(userId);
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