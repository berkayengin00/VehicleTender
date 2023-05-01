using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.Tramer;

namespace VehicleTender.AdminUI.Controllers
{
    public class TramerController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
	        return View(new TramerDal().GetTramerAddVM());
        }


        [HttpPost]
        public ActionResult Add(string jsonData)
        {
	        var serializer = new JavaScriptSerializer();
            Session["Tramer"] = serializer.Deserialize<List<TramerAddVM>>(jsonData);

            if (Session["Tramer"] != null)
            {
                return RedirectToAction("Add", "Vehicle");
            }
            // todo : hata mesajı gösterilecek
            return View();

        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var result = new VehicleTramerDal().GetAllByVehicleId(id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            // todo : hata mesajı gösterilecek
            return View();
        }
    }
}