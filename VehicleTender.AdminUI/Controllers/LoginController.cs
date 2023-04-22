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
			var test = Request.Cookies["loginInfo"];
			LoginVM vm = new LoginVM();
			if (test != null)
			{
				
				var httpCookie = Request.Cookies["loginInfo"];
				vm.Email = httpCookie.Values["email"];
				vm.RememberMe = bool.Parse(httpCookie.Values["rememberme"]);
			}
			return View(vm);
		}

		[HttpPost]
        public ActionResult Index(LoginVM vm)
        {
	        var result = new LoginDal().CheckAdmin(vm);

	        if (result.IsSuccess && Session["Admin"]==null)
	        {
				RememberMe(vm.RememberMe,vm.Email);
				Session.Add("Admin",result.Data);
				FormsAuthentication.SetAuthCookie(result.Data.Email,true);
				return RedirectToAction("Index", "Admin");
			}

	        return View("Index");
        }

        public void RememberMe(bool rememberMe,string email)
        {
	        // beni hatırla seçili ise ve daha önce beni hatırla yapılmamışsa girer
	        HttpCookie cookie = new HttpCookie("loginInfo");
	        if (rememberMe && Request.Cookies["loginInfo"] == null)
	        {

		        cookie.Expires = DateTime.Now.AddDays(1);
		        cookie.Values.Add("email",email );
		        cookie.Values.Add("rememberme", "true");
		        HttpContext.Response.Cookies.Add(cookie);
	        }
	        else if (Request.Cookies["loginInfo"] != null && !rememberMe)// cookie varsa ve beni hatırla seçili ise girer
	        {
		        cookie.Expires = DateTime.Now.AddDays(-1);
		        HttpContext.Response.Cookies.Add(cookie);
	        }
        }
	}
}