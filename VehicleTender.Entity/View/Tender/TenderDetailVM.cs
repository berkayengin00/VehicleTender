using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.Tender
{
	public class TenderDetailVM
	{
		public int TenderDetailId { get; set; }
		public int VehicleId { get; set; }
		public decimal MinPrice { get; set; }
		public decimal StartPrice { get; set; }
	}
}
