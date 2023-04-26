using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using VehicleTender.AdminUI.Filters;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

namespace VehicleTender.AdminUI.Controllers
{
	[Authorize,CheckRole("Admin","Lale","Sumbul")]
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			if (Session["Admin"] != null)
			{
				return RedirectToAction("GetAll", "RetailCustomer");
			}
			return RedirectToAction("Index","Login");

		}

		public PartialViewResult Footer()
		{
			return PartialView();
		}

	}

}