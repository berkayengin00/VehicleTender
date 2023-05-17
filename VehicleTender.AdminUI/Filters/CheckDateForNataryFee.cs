using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.Entity.View;

namespace VehicleTender.AdminUI.Filters
{
	public class CheckDateForNotaryFee:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var vm = filterContext.ActionParameters["vm"] as NotaryFeeVM;
			DateTime addedDate = vm.StartDate;
			DateTime endDate = vm.EndDate;


			if (addedDate > endDate)
			{
				filterContext.Controller.TempData.Add("message", "Başlangıç tarihi bitiş tarihinden önce olamaz");
				filterContext.Result = new RedirectResult("/NotaryFee/GetAll");
			}
			else if (addedDate < DateTime.Now)
			{
				filterContext.Controller.TempData.Add("message", "Başlangıç tarihi bugünden önce olamaz");
				filterContext.Result = new RedirectResult("/NotaryFee/GetAll");
			}
			else
			{
				base.OnActionExecuting(filterContext);
			}
		}
	}
}