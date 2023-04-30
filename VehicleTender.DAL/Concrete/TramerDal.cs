using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Tramer;

namespace VehicleTender.DAL.Concrete
{
	public class TramerDal:CrudRepository<Tramer>
	{
		public TramerDal() : base(new EfVehicleTenderContext())
		{
		}

		public TramerAddVM GetTramerAddVM()
		{
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				return new TramerAddVM()
				{
					VehiclePartStatus = db.VehiclePartStatus
						.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),
					TramerList = db.Tramers.Select(x => new SelectListItem()
						{ Text = x.TramerName, Value = x.Id.ToString() }).ToList()
				};
			}
		}
	}
}
