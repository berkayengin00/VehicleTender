using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

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
			vm.CreatedById = vm.CreatedById = GetUserId();
			
			Session.Add("Tender",vm);
			return RedirectToAction("AddDetail");
		}

		public ActionResult AddDetail()
		{
			
			return View(new TenderDetailAddVMForAdmin());
		}

		[HttpPost]
		public ActionResult AddDetail(string jsonData)
		{
			var serializer = new JavaScriptSerializer();
			var data = serializer.Deserialize<List<TenderDetailAddVMForAdmin>>(jsonData);
			TenderAndTenderDetailVmForAdmin detailVm = new TenderAndTenderDetailVmForAdmin()
			{
				tenderDetailList = data,
				TenderAddVmForAdmin = Session["Tender"] as TenderAddVMForAdmin
			};

			new TenderDal().AddTender(detailVm);
			Session.Clear();
			return RedirectToAction("Add");
		}

		public ActionResult GetAll()
		{
			return View(new TenderDal().GetAll());
		}

		public ActionResult SoftDelete(int tenderId)
		{
			new TenderDal().SoftDelete(tenderId);
			return RedirectToAction("GetAll");
		}

		[NonAction]
		public int GetUserId()
		{
			return Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}
	}
}