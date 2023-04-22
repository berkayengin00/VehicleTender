using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class CorporateCustomerDal:CrudRepository<CorporateCustomer>
	{
		public CorporateCustomerDal() : base(new EfVehicleTenderContext())
		{
		}
	}
}
