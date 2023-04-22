using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Result;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.DB;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleDal:CrudRepository<Vehicle>
	{
		public VehicleDal() : base(new EfVehicleTenderContext())
		{

		}

		public int Add(DbVehicleAddVmForAdmin vm)
		{
			vm.CreatedDate= DateTime.Now;
			return base.Insert(new Vehicle()
			{
				BodyTypeId = vm.BodyTypeId,
				ColorId = vm.ColorId,
				FuelTypeId = vm.FuelTypeId,
				GearTypeId = vm.GearTypeId,
				CreatedBy = 1,
				CreatedDate = DateTime.Now,
				UpdatedBy = 1,
				UpdatedDate = DateTime.Now,
				IsActive = true,
				ModelId = vm.ModelId,
				Version = vm.Version,
				KiloMeter = vm.KiloMeter,
				Description = vm.Description,
				VehicleAge = DateTime.Now.Date,
			});
		}





		
	}
}
