using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.Entity.View
{
	public class TenderDetailAddVMForAdmin
	{
		public int TenderId { get; set; }
		public int VehicleId { get; set; }
		public decimal MinPrice { get; set; }
		public decimal StartPrice { get; set; }

		public List<SelectListItem> Vehicles { get; set; }
	}
}
