using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
		public ActionResult Index()
		{
			return View(new LoginVM());
		}

		[HttpPost]
        public ActionResult Index(LoginVM vm)
        {
	        var result = new LoginDal().CheckAdmin(vm);
	        if (result.IsSuccess && Session["Admin"]==null)
	        {
				Session["Admin"] = result.Data.Email;
				FormsAuthentication.SetAuthCookie(result.Data.Email,true);
				return RedirectToAction("Index", "Admin");
			}

	        return View("Index");
        }
    }
}