using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;

namespace VehicleTender.AdminUI.Controllers
{
    public class TramerController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
	        return View(new TramerDal().GetTramerAddVM());
        }
    }
}