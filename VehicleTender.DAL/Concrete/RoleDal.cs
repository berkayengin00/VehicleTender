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
	public class RoleDal:CrudRepository<Role>
	{
		public RoleDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllRoles()
		{
			return Select(x => new SelectListItem()
			{
				Text = x.RoleName,
				Value = x.Id.ToString()
			});
		}
	}
}
