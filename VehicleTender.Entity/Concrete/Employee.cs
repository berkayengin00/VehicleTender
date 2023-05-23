using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class Employee:User
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }

	}
}
