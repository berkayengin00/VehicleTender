using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.DAL.Concrete
{
	public class ProvinceDal
	{
		public List<SelectListItem> GetAll()
		{
			List<SelectListItem> result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = db.Province.Select(x=> new SelectListItem()
				{
					Text = x.Name,
					Value = x.Id.ToString()
				}).ToList();
			}
			return result;
		}
	}
}
