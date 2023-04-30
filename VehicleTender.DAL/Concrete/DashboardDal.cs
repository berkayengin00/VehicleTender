using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class DashboardDal
	{
		public DashboardVmForAdmin GetCount()
		{
			DashboardVmForAdmin result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from retail in db.RetailCustomers
					select new DashboardVmForAdmin()
					{
						CorporateCustomerType = db.CorporateCustomers.Count(),
						EmployeeCount = db.Employees.Count(),
						VehicleCount = db.Vehicles.Count(),
						RetailCustomerCount = db.RetailCustomers.Count(),
						StockCount = db.Stocks.Count(),
						TenderCount = db.Tenders.Count()
					}).SingleOrDefault();
			} 
			return result;
		}
	}
}
