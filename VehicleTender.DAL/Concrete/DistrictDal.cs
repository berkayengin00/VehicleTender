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
	public class DistrictDal:CrudRepository<District>
	{
		public DistrictDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<District> GetAll()
		{
			return base.GetAll();
		}

	}
}
