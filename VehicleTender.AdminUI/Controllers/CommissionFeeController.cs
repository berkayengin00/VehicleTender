using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
    public class CommissionFeeController : Controller
    {
        // GET: CommissionFee
        public ActionResult AddOrUpdate(int id)
        {
	        if (id == 0)
	        {
		        return View(new CommissionFeeVM());
	        }
            return View(new CommissionFeeDal().GetById(id).Data);
        }

		[HttpPost,ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(CommissionFeeVM vm)
        {
	        if (vm.Id==0)
	        {
		        new CommissionFeeDal().Add(vm);
				return RedirectToAction("GetAll");
	        }
			//new CommissionFeeDal().Update(vm);	
	        return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
	        return View(new CommissionFeeDal().GetAll().Data);
		}

        public ActionResult SoftDelete(int id)
        {
			return RedirectToAction("GetAll");
		}
	}
}