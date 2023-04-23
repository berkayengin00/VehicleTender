using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
    public class TenderController : Controller
    {
		// GET: Tender

		public ActionResult Add()
		{
			TenderAddVMForAdmin vm = new TenderAddVMForAdmin()
			{
				CompanyNames = new CorporateCustomerDal().GetAllCompanyName(),
				TenderTypes = new TenderTypeDal().GetAllTenderTypes(),
			};
			return View(vm);
		}

		[HttpPost]
		public ActionResult Add(TenderAddVMForAdmin vm)
		{
			return View();
		}
	}
}