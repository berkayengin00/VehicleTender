using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class FuelDal : CrudRepository<FuelType>
	{
		public FuelDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllFuelTypes()
		{
			return base.Select<SelectListItem>(x => new SelectListItem()
			{
				Text = x.Id.ToString(),
				Value = x.Name
			});
		}
	}
}