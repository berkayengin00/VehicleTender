using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.Entity.View.Vehicle
{
	public class VehicleUpdateVM
	{
		public int VehicleId { get; set; }
		[DisplayName("Plaka")]
		public string LicensePlate { get; set; }
		[DisplayName("Model Yılı")]
		public short VehicleYear { get; set; }
		[DisplayName("Versiyon")]
		public string Version { get; set; }
		[DisplayName("Kilometre")]
		public int KiloMeter { get; set; }
		[DisplayName("Açıklama")]
		public string Description { get; set; }
		[DisplayName("Güncelleyen")]
		public int UpdatedBy { get; set; }
		[DisplayName("Güncelleme Tarihi")]
		public DateTime UpdatedDate { get; set; }=DateTime.Now;
		[DisplayName("Vites Tipi")]
		public int GearTypeId { get; set; }
		[DisplayName("Yakıt Tipi")]
		public int FuelTypeId { get; set; }
		[DisplayName("Kasa Tipi")]
		public int BodyTypeId { get; set; }
		[DisplayName("Model")]
		public int ModelId { get; set; }
		[DisplayName("Renk")]
		public int ColorId { get; set; }
		[DisplayName("Marka")]
		public int BrandId { get; set; }

		public DateTime StatusChangedDate { get; set; }=DateTime.Now;
		public VehicleFeaturesForCache VehicleFeaturesForCache { get; set; }
		public int VehicleStatusId { get; set; }
		public List<SelectListItem> VehicleStatusList { get; set; }
		public List<VehicleImageVM> vehicleImages { get; set; }
	}
}
