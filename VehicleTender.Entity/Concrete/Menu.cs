using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class Menu:BaseEntity
	{
		public string Name { get; set; }
		public string Url { get; set; }
	}
}
