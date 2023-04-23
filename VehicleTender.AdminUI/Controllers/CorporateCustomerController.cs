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

		[HttpPost]
		public ActionResult Add(CorporateCustomerAddVM vm)
		{
			int result = new CorporateCustomerDal().Add(vm);
			ViewBag.Result = result > 0 ? "Kurumsal Müşteri Kaydedildi" : "Hata!!!";
			return result > 0 ? View("GetAll") : View("Add");

		}
	}
}