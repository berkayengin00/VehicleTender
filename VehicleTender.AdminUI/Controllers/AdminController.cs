using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.AdminUI.Controllers
{
    public class AdminController : Controller
    {
		// GET: Admin
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetAllCars()
		{

			return View();
		}

		[HttpPost]
		public ActionResult AddCar()
		{
			return View();
		}

		public ActionResult RetailCustomersGetAll()
		{
			List<RetailCustomer> list = new RetailCustomerDal().GetAll();
			return View(list);
		}

		public ActionResult RetailCustomerAdd()
		{
			return View();
		}

		[HttpPost]
		public ActionResult RetailCustomerAdd(RetailCustomer retailCustomer)
		{
			return View();
		}

		public ActionResult CorporateCustomersGetAll()
		{
			List<CorporateCustomer> list = new CorporateCustomerDal().GetAll();
			return View(list);
		}

		[HttpPost]
		public ActionResult CorporateCustomerAdd(CorporateCustomer corporateCustomer)
		{
			return View();
		}
	}
}