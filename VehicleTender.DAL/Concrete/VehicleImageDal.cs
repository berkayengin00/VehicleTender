using System.Collections.Generic;
using System.Data.Entity;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleImageDal:CrudRepository<VehicleImage>
	{
		public VehicleImageDal() : base(new EfVehicleTenderContext())
		{
		}

		public void ImagesAdd(int vehicleId,List<string> imgPaths)
		{

		}
		
	}
}