using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class CorporatePackageDal:CrudRepository<CorporatePackage>
	{
		public CorporatePackageDal() : base(new EfVehicleTenderContext())
		{
		}

	}
}
