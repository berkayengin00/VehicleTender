using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View
{
	public class DashboardVmForAdmin
	{
		public int RetailCustomerCount { get; set; }
		public int CorporateCustomerType { get; set; }
		public int EmployeeCount { get; set; }
		public int StockCount { get; set; }
		public int VehicleCount { get; set; }
		public int TenderCount { get; set; }
	}
}
