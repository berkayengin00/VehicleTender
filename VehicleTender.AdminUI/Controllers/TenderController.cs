using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View.Tender;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize]
	public class TenderController : Controller
	{
		// GET: Tender
		[HttpGet]
		public ActionResult Add()
		{
			var vm = new TenderAddVMForAdmin()
			{
				CompanyNames = new CorporateCustomerDal().GetAllCompanyName(),
				TenderTypes = new TenderTypeDal().GetAllTenderTypes(),
			};
			return View(vm);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Add(TenderAddVMForAdmin vm)
		{
			vm.CreatedById = vm.CorporateId;

			Session.Add("Tender", vm);
			return RedirectToAction("AddDetail", new { @userId = vm.CorporateId });
		}

		[HttpGet]
		public ActionResult AddDetail(int userId)
		{
			var result = new TenderDetailAddVMForAdmin()
			{
				Vehicles = new VehicleDal().GetAllVehicleByUserType(userId)
			};

			return View(result);
		}

		[HttpPost]
		public ActionResult AddDetail(string jsonData)
		{
			if (Session["Tender"] == null) return RedirectToAction("Add");
			var detailVm = CheckSessionAndSessionDetail(jsonData);

			var result = new TenderDal().AddTender(detailVm);
			if (!result.IsSuccess) return RedirectToAction("Add");

			Session.Remove("Tender");
			return RedirectToAction("GetAll");
			// todo hata ver ve o sayfaya yönlendir
		}

		[HttpGet]
		public ActionResult GetAll()
		{
			var result = new TenderDal().GetAll();
			if (result.IsSuccess)
			{
				return View(result.Data);
			}
			return RedirectToAction("Page404", "MyError");
		}

		[HttpGet]
		public ActionResult SoftDelete(int tenderId)
		{
			var result = new TenderDal().SoftDelete(tenderId);
			if (result.IsSuccess)
			{
				return RedirectToAction("GetAll");
			}

			return RedirectToAction("Page404","MyError");

		}

		// todo update işlemi yapılacak hata veriyor
		[HttpGet]
		public ActionResult Update(int tenderId)
		{

			var vm = new TenderDal().GetTenderById(tenderId);
			return View(vm);
		}

		[HttpPost]
		public ActionResult Update(TenderUpdateVMForAdmin vm)
		{
			return View();
		}

		public ActionResult DeleteDetail(int id)
		{
			if (Session["deleteDetail"] != null)
			{
				string deletedDetails = Session["deleteDetail"].ToString();
				deletedDetails += id;
				Session.Add("deleteDetail", id);
			}
			else
			{
				Session.Add("deleteDetail", id);
			}

			return RedirectToAction("Update");
		}

		[NonAction]
		public int GetUserId()
		{
			return Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="jsonData"></param>
		/// <returns></returns>
		[NonAction]
		public TenderAndTenderDetailVmForAdmin CheckSessionAndSessionDetail(string jsonData)
		{
			var serializer = new JavaScriptSerializer();
			var data = serializer.Deserialize<List<TenderDetailAddVMForAdmin>>(jsonData);

			return  new TenderAndTenderDetailVmForAdmin()
			{
				tenderDetailList = data,
				TenderAddVmForAdmin = Session["Tender"] as TenderAddVMForAdmin
			};
		}


	}
}