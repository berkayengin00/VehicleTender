using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class TenderTypeDal:CrudRepository<UserType>
	{
		public TenderTypeDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllTenderTypes()
		{
			return base.Select(x => new SelectListItem()
			{
				Value = x.Id.ToString(),
				Text = x.Name
			});
		}
	}
}
