using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View
{
	public class VehicleVMForAdmin
	{
		public int VehicleId { get; set; }
		public DateTime VehicleAge { get; set; }
		public string Version { get; set; }
		public int KiloMeter { get; set; }
		public string Description { get; set; }
		public string GearType { get; set; }
		public string FuelType { get; set; }
		public string BodyType { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public string Color { get; set; }
		public string StatusName { get; set; }
		public int VehicleStatusId { get; set; }
		public string EmailOfTheAdder { get; set; }
		
	}
}
