using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.Tramer
{
	public class TramerListVM
	{
		public string TramerName { get; set; }
		public string PartName { get; set; }
		public decimal PartPrice { get; set; }
	}
}
