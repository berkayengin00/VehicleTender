using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
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
						StockCountByPlaza = db.Stocks.Count(x=>x.UserTypeId==(int)UserTypeEnum.Plaza),
						StockCountByCorporate = db.Stocks.Count(x=>x.UserTypeId==(int)UserTypeEnum.Corporate),
						TenderCountByCorporate = db.Tenders.Count(x=>x.TenderTypeId==(int)UserTypeEnum.Corporate),
						TenderCountByRetired = db.Tenders.Count(x=>x.TenderTypeId==(int)UserTypeEnum.Retired)
					}).FirstOrDefault();
			} 
			return result;
		}
	}
}
