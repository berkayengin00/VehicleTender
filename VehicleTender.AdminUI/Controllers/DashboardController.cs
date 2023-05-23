using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;

namespace VehicleTender.AdminUI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View(new DashboardDal().GetCount());
        }
    }
}