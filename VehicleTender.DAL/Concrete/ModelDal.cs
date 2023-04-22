using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class ModelDal : CrudRepository<Model>
	{
		public ModelDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllModels()
		{
			return base.Select<SelectListItem>(x => new SelectListItem()
			{
				Value = x.Id.ToString(),
				Text = x.ModelName
			});
		}
	}
}