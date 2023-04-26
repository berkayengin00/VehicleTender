using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using static System.Collections.Specialized.BitVector32;

namespace VehicleTender.AdminUI.Filters
{
	public class CheckUser : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{

			//base.OnActionExecuting(filterContext);

			if (filterContext.ActionParameters["loginVm"] != null)
			{
				var vm = filterContext.ActionParameters["loginVm"] as LoginVM;
				
				
				var userResult = new LoginDal().CheckAdmin(vm);

				// db ye gidip sessiondaki değere karşılaştırma yap
				if (userResult.IsSuccess)
				{

					if (HttpContext.Current.Session["Admin"] != null)
					{
						filterContext.Result = new RedirectResult("RetailCustomer/GetAll");
					}
					//var result = new LoginDal().CheckAdmin(vm);

					if (HttpContext.Current.Session["Admin"] == null)
					{
						RememberMe(vm.RememberMe, vm.Email);
						HttpContext.Current.Session.Add("Admin", userResult.Data);
						FormsAuthentication.SetAuthCookie(userResult.Data.Email, true);
						filterContext.Result = new RedirectResult("/Admin/Index");
					}

					//filterContext.Result = new RedirectResult("/Account/LogIn");
					


					//if (HttpContext.Current.Session["userInfo"] == null)
					//{
					//	FormsAuthentication.SetAuthCookie(userResult.Data, true);
					//}

					//HttpContext.Current.Session.Add("deger","hoppala!");
				}
				//else
				//{
				//	// log al
				//	// nlog ?? db ye log al bir framework var nlog adında
				//	filterContext.Result = new RedirectResult("/Account/LogIn"); // işlem başarısız olursa bu adrese git
				//}
			}

			//if (HttpContext.Current.Session["veri"]!=null)
			//{
			//	// db ye gidip sessiondaki değere karşılaştırma yap
			//}


			//if (filterContext.HttpContext.Session["adminInfo"] == null)
			//{
			//	filterContext.Result = new RedirectResult("/Login/Index");
			//}
			base.OnActionExecuting(filterContext);
		}

		public void RememberMe(bool rememberMe, string email)
		{
			// beni hatırla seçili ise ve daha önce beni hatırla yapılmamışsa girer
			HttpCookie cookie = new HttpCookie("loginInfo");
			if (rememberMe && HttpContext.Current.Request.Cookies["loginInfo"] == null)
			{

				cookie.Expires = DateTime.Now.AddDays(1);
				cookie.Values.Add("email", email);
				cookie.Values.Add("rememberme", "true");
				HttpContext.Current.Response.Cookies.Add(cookie);
			}
			else if (HttpContext.Current.Request.Cookies["loginInfo"] != null && !rememberMe)// cookie varsa ve beni hatırla seçili ise girer
			{
				cookie.Expires = DateTime.Now.AddDays(-1);
				HttpContext.Current.Response.Cookies.Add(cookie);
			}
		}
	}
}