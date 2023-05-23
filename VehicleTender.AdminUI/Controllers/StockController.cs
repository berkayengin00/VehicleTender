using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;

namespace VehicleTender.AdminUI.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult GetAll()
        {
            return View(new StockDal().GetAllForAdmin());
        }
    }
}