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
		[DisplayName("Parça Fiyatı")]
		public decimal PartPrice { get; set; }
		public DateTime AddDateTime { get; set; }=DateTime.Now;



		public List<SelectListItem> TramerList { get; set; }
		public List<SelectListItem> VehiclePartStatus { get; set; }
	}


	public class TramerAddVMWithOutVehicle
	{
		[DisplayName("Tramer Seçiniz")]
		public int TramerId { get; set; }
		[DisplayName("Parça Durumu")]
		public int VehiclePartId { get; set; }
		[DisplayName("Parça Fiyatı")]
		public decimal PartPrice { get; set; }
		public DateTime AddDateTime { get; set; } = DateTime.Now;
		public int VehicleId { get; set; }

		public List<SelectListItem> TramerList { get; set; }
		public List<SelectListItem> VehiclePartStatus { get; set; }
	}
}
