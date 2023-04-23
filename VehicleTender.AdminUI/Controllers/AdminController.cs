using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		// GET: Admin
		private int adminId = 0;
		public ActionResult Index()
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
			// todo vehicleage için view üzerinde ekleme yapılacak
			vm.UserId = GetUserId();
			var result = new VehicleDal().Add(vm);
			return RedirectToAction("AddVehicle");
		}

		public ActionResult GetAllVehicle()
		{
			var list = new VehicleDal().GetAllForAdmin();
			return View(list);
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

		public ActionResult TenderAdd()
		{
			TenderAddVMForAdmin vm = new TenderAddVMForAdmin()
			{
				CompanyNames = new CorporateCustomerDal().GetAllCompanyName(),
				TenderTypes	= new TenderTypeDal().GetAllTenderTypes(),
			};
			return View(vm);
		}

		[HttpPost]
		public ActionResult TenderAdd(TenderAddVMForAdmin vm)
		{
			return View();
		}

		/// <summary>
		///	Sistemde kayıtlı olan adminin id'sini döndürür.
		/// </summary>
		/// <returns></returns>
		[NonAction]
		public int GetUserId()
		{
			return adminId = Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}


	}
}