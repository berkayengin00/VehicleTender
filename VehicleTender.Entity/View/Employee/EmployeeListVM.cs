using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.Employee
{
	public class EmployeeListVM
	{
		public int EmployeeId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string RoleName { get; set; }
		public bool IsActive { get; set; }
		
	}
}
