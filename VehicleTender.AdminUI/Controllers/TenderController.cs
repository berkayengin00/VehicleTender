using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleTender.AdminUI.Controllers
{
    public class TenderController : Controller
    {
        // GET: Tender
        public ActionResult Index()
        {
            return View();
        }
    }
}