using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

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
		
		public ActionResult AddVehicle()
		{
			var result = new VehicleAddVMForAdmin()
			{
				Brands = new BrandDal().GetAllBrand(),
				BodyTypes = new BodyTypeDal().GetAllBodyTypes(),
				Colors = new ColorDal().GetAllColors(),
				FuelTypes = new FuelDal().GetAllFuelTypes(),
				GearTypes = new GearTypeDal().GetAllGearTypes(),
				Models = new ModelDal().GetAllModels(),
			};
			return View(result);
		}

		[HttpPost]
		public ActionResult AddVehicle(DbVehicleAddVmForAdmin vm)
		{
			var result = new VehicleDal();
			return RedirectToAction("AddVehicle");
		}

		public ActionResult RetailCustomersGetAll()
		{
			List<RetailCustomer> list = new RetailCustomerDal().GetAll();
			return View(list);
		}

		public ActionResult RetailCustomerAdd()
		{
			return View(new RetailCustomerAddVM());
		}

		[HttpPost]
		public ActionResult RetailCustomerAdd(RetailCustomerAddVM vm)
		{
			int result = new RetailCustomerDal().Add(vm);
			return RedirectToAction("RetailCustomerAdd");
		}

		public ActionResult CorporateCustomersGetAll()
		{
			List<CorporateCustomer> list = new CorporateCustomerDal().GetAll();
			return View(list);
		}
		
		public ActionResult CorporateCustomerAdd()
		{
			return View(new CorporateCustomerAddVM());
		}

		[HttpPost]
		public ActionResult CorporateCustomerAdd(CorporateCustomerAddVM vm)
		{
			int result = new CorporateCustomerDal().Add(vm);
			ViewBag.Result = result > 0 ? "Kurumsal Müşteri Kaydedildi" : "Hata!!!";
			return result > 0 ? View("Index") : View("CorporateCustomerAdd");

		}
	}
}