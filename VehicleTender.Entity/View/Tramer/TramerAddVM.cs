using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.Entity.View.Tramer
{
	public class TramerAddVM
	{
		[DisplayName("Tramer Seçiniz")]
		public int TramerId { get; set; }
		[DisplayName("Parça Durumu")]
		public int VehiclePartId { get; set; }
		
		public List<SelectListItem> TramerList { get; set; }
		public List<SelectListItem> VehiclePartStatus { get; set; }
	}
}
