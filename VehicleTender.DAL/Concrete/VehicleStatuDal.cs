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
	public class VehicleStatuDal:CrudRepository<VehicleStatus>
	{
		public VehicleStatuDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllVehicleStatuses()
		{
			return Select(x => new SelectListItem()
			{
				Text = x.StatusName,
				Value = x.Id.ToString(),
			}).ToList();
		}

	}
}
