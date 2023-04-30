using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class VehiclePrice:BaseEntity
	{
		public decimal Price { get; set; }
		public int VehicleId { get; set; }
		public DateTime AddedDate { get; set; }

		public Vehicle Vehicle { get; set; }

	}
}
