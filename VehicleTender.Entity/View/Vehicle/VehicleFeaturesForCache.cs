using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.Entity.View.Vehicle
{
	public class VehicleFeaturesForCache
	{
		public List<SelectListItem> GearTypes { get; set; }
		public List<SelectListItem> FuelTypes { get; set; }
		public List<SelectListItem> BodyTypes { get; set; }
		public List<SelectListItem> Colors { get; set; }
		public List<SelectListItem> Brands { get; set; }
		public List<SelectListItem> Models { get; set; }
	}
}
