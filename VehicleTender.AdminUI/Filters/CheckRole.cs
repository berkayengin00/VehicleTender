using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Filters
{
	public class CheckRole:ActionFilterAttribute
	{
		private List<string> _roles;
		public CheckRole(params string[] roles)
		{
			_roles = roles.ToList();
		}
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (HttpContext.Current.Session["Admin"] == null)
			{
				filterContext.Result = new RedirectResult("/Login/Index");
			}
			else
			{
				var userRoles = (HttpContext.Current.Session["Admin"] as SessionVMForAdmin)?.Roles;
				bool isAuthorized = false;
				foreach (var item in _roles)
				{
					foreach (var userRole in userRoles)
					{
						if (item == userRole.RoleName)
						{
							// işleme devam et
							isAuthorized =true;
							return;
						}
					}
				}

				if (!isAuthorized)
				{
					filterContext.Result = new RedirectResult("/Login/Index");
				}
			}
			base.OnActionExecuting(filterContext);
		}
	}
}