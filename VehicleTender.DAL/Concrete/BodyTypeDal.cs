using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class BodyTypeDal:CrudRepository<BodyType>
	{
		public BodyTypeDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllBodyTypes()
		{
			return base.Select(x=> new SelectListItem()
			{
				Text = x.Name,
				Value = x.Id.ToString()
			});
		}
	}
}
