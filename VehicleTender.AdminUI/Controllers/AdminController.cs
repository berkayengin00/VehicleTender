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
		public ActionResult Index()
		{
			return RedirectToAction("GetAll","RetailCustomer");
		}

		public PartialViewResult Footer()
		{
			return PartialView();
		}

	}
}