using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.Employee;

namespace VehicleTender.AdminUI.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Employee
		public ActionResult AddOrUpdate(int id)
		{
			EmployeeAddVM result = new EmployeeAddVM();
			if (id != 0)
			{
				result = new EmployeeDal().Get(id);
			}

			result.Roles = new RoleDal().GetAllRoles();
			return View(result);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult AddOrUpdate(EmployeeAddVM vm)
		{
			vm.UpdatedBy = GetUserId();
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

		public ActionResult GetAll()
		{
			return View(new EmployeeDal().GetAll());
		}

		public ActionResult SoftDelete()
		{
			return View();
		}

		public int GetUserId()
		{
			return Session["Admin"] != null ? (Session["Admin"] as SessionVMForAdmin).AdminId : 0;
		}
	}
}