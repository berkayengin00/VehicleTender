using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleTender.DAL.Results;
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
				filterContext.Controller.TempData.Add("message", new Result("Başlangıç tarihi bitiş tarihinden önce olamaz",false));
				filterContext.Result = new RedirectResult("/NotaryFee/AddOrUpdate/0");
			}
			else if (addedDate < DateTime.Now)
			{
				filterContext.Controller.TempData.Add("message", new Result("Başlangıç tarihi bugünden önce olamaz",false));
				filterContext.Result = new RedirectResult("/NotaryFee/AddOrUpdate/0");
			}
			else
			{
				base.OnActionExecuting(filterContext);
			}
		}
	}
}