using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VehicleTender.DAL.Concrete;
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

        // todo eğer aracın trameri yoksa tramer ekleme sayfasına yönlendirilecek
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
            if (result.IsSuccess && result.Data.Count>0)
            {
                return View(result.Data);
            }
            // todo : hata mesajı gösterilecek
            return RedirectToAction("Add");
        }

        public ActionResult Update(string jsonData)
        {
	        var serializer = new JavaScriptSerializer();
	        var list = serializer.Deserialize<List<TramerAddVMWithOutVehicle>>(jsonData);

	        new VehicleTramerDal().AddWithoutVehicle(list);

			return RedirectToAction("GetAll","Vehicle");
        }
    }
}