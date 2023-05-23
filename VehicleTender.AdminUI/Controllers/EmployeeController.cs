using System;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.Mvc;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.Employee;

namespace VehicleTender.AdminUI.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Employee
		[HttpGet]
		public ActionResult AddOrUpdate(int id)
		{
			EmployeeAddVM result = new EmployeeAddVM();
			if (id != 0)
			{
				result = new EmployeeDal().Get(id);
			}

			result.Roles = CheckCache();
			return View(result);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AddOrUpdate(EmployeeAddVM vm)
		{
			vm.UpdatedBy = GetUserId();

			if (ModelState.IsValid)
			{
				if (vm.EmployeeId != 0)
				{
					vm.UpdatedDate = DateTime.Now;
					new EmployeeDal().Update(vm);
				}
				else
				{
					vm.CreatedBy = GetUserId();
					new EmployeeDal().Add(vm);
				}
				return RedirectToAction("GetAll");
			}
			vm.Roles=CheckCache();
			return View(vm);

		}

		[HttpGet]
		public ActionResult GetAll()
		{
			return View(new EmployeeDal().GetAll());
		}


		public ActionResult SoftDelete(int id)
		{
			if (new EmployeeDal().SoftDelete(id).IsSuccess)
			{
				return RedirectToAction("GetAll");
			}
			// todo : hata mesajı göster
			return RedirectToAction("GetAll");

		}
		[NonAction]
		public int GetUserId()
		{
			return Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}

		[NonAction]
		public List<SelectListItem> CheckCache()
		{
			if (HttpContext.Cache["userType"] != null)
				return HttpContext.Cache["userType"] as List<SelectListItem>;

			var roles= new RoleDal().GetAllRoles();
			HttpContext.Cache.Insert("userType", roles, null, Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
			return roles;
		}
	}
}