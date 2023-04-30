using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.Entity.View
{
	public class SessionVMForAdmin
	{
		public int AdminId { get; set; }
		public string Email { get; set; }
		public List<Role> Roles { get; set; }
		public List<Menu> Menus { get; set; }
		
	}
}
