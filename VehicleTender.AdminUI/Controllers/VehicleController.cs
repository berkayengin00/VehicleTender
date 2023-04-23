﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
    public class VehicleController : Controller
    {
		// GET: Vehicle
		public ActionResult Add()
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
		public ActionResult Add(DbVehicleAddVmForAdmin vm)
		{
			// todo vehicleage için view üzerinde ekleme yapılacak
			vm.UserId = GetUserId();
			var result = new VehicleDal().Add(vm);
			return RedirectToAction("Add");
		}

		public ActionResult GetAll()
		{
			var list = new VehicleDal().GetAllForAdmin();
			return View(list);
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