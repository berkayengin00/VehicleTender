using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.VehicleStatusHistory
{
	public class VehicleStatusHistoryVM
	{
		public string LicensePlate { get; set; }
		public string VehicleStatusHistory { get; set; }
		public DateTime ChangedDataTime { get; set; }

	}
}
