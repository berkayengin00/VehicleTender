using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
    public class RetailCustomerController : Controller
    {
		// GET: RetailCustomer
		public ActionResult Add()
		{
			return View(new RetailCustomerAddVM());
		}

		[HttpPost]
		public ActionResult Add(RetailCustomerAddVM vm)
		{
			int result = new RetailCustomerDal().Add(vm);
			return RedirectToAction("Add");
		}

		public ActionResult GetAll()
		{
			List<RetailCustomer> list = new RetailCustomerDal().GetAll();
			return View(list);
		}
	}
}