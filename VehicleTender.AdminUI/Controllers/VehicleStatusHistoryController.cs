using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;

namespace VehicleTender.AdminUI.Controllers
{
    public class VehicleStatusHistoryController : Controller
    {
        // GET: VehicleStatusHistory
       
        public ActionResult GetAll(int id)
        {
            var result = new VehicleStatusHistoryDal().GetAll(id);
	        return View(result);
        }
	}
}