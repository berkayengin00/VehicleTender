using System.Collections.Generic;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class GearTypeDal : CrudRepository<GearType>
	{
		public GearTypeDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllGearTypes()
		{
			return base.Select<SelectListItem>(x => new SelectListItem()
			{
				Value = x.Id.ToString(),
				Text = x.Name
			});
		}
	}
}