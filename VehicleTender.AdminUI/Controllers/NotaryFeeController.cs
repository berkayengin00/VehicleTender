using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.AdminUI.Filters;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
	public class NotaryFeeController : Controller
	{
		// GET: NotaryFee
		[HttpGet]
		public ActionResult AddOrUpdate(int id)
		{
			if (id == 0)
			{
				return View(new NotaryFeeVM());
			}
			return View(new NotaryFeeDal().GetById(id).Data);
		}

		[CheckDateForNotaryFee]
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AddOrUpdate(NotaryFeeVM vm)
		{
			if (vm.Id == 0)
			{
				var result = new NotaryFeeDal().Add(vm);
				if (result.IsSuccess)
				{
					return RedirectToAction("GetAll");
				}

				return RedirectToAction("AddOrUpdate");
			}
			return View(vm);
		}

		[HttpGet]
		public ActionResult GetAll()
		{
			var result = new NotaryFeeDal().GetAll();
			if (result.IsSuccess)
			{
				return View(result.Data);
			}
			// TODO: hata sayfası yapılacak
			return View();

		}

		public ActionResult SoftDelete(int id)
		{
			return View();
		}

	}
}