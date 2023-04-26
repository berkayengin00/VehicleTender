﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VehicleTender.AdminUI.Filters;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
		public ActionResult Index()
		{
			
			if (ModelState.IsValid && Session["Admin"]!=null)
			{
				return RedirectToAction("Index", "Admin");
			}
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

		[HttpPost,CheckUser,ValidateAntiForgeryToken]
        public ActionResult Index(LoginVM loginVm)
        {
	        if (!ModelState.IsValid)
	        {
		        return RedirectToAction("Index");
		      
	        }
	        return RedirectToAction("Index","Admin");
        }
		[NonAction]
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
        public ActionResult LogOut()
        {
			FormsAuthentication.SignOut();
			Session.Clear();
			return RedirectToAction("Index");
        }
	}
}