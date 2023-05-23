using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Vehicle;

namespace VehicleTender.Entity.View
{
	public class VehicleAddVMForAdmin
	{
		[DisplayName("Plaka")]
		[StringLength(8,ErrorMessage = "Plaka En Fazla 8 hane olmalıdır")]
		public string LicensePlate { get; set; }
		
		[DisplayName("Model Yılı")]
		[Range(1900, 2100, ErrorMessage = "Model Yılı 1900 ile 2100 arasında olmalıdır")]
		public short VehicleYear { get; set; }
		
		[DisplayName("Versiyon")]
		[StringLength(50,ErrorMessage = "Versiyon En Fazla 50 karakter olmalıdır")]
		public string Version { get; set; }
		[DisplayName("Kilometre")]
		[Range(0, 1000000, ErrorMessage = "Kilometre 0 ile 1000000 arasında olmalıdır")]
		public int KiloMeter { get; set; }
		
		[DisplayName("Açıklama")]
		[StringLength(300,ErrorMessage = "Açıklama En Fazla 300 karakter olmalıdır")]
		public string Description { get; set; }
		
		[DisplayName("Oluşturan")]
		public int CreatedBy { get; set; }
		[DisplayName("Oluşturulma Tarihi")]
		public DateTime CreatedDate { get; set; }
		[DisplayName("Güncelleyen")]
		public int UpdatedBy { get; set; }
		[DisplayName("Güncelleme Tarihi")]
		public DateTime UpdatedDate { get; set; }
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
		[DisplayName("Bireysel/Kurumsal ?")]
		public int UserTypeId { get; set; }
		[DisplayName("Kullanıcı Seçiniz")]
		public int UserId { get; set; }

		
		[DisplayName("Fiyat Giriniz")] [Obsolete]
		[Range(100, 100000000, ErrorMessage = "Fiyat 100 ile 100000000 arasında olmalıdır")]
		public decimal VehiclePrice { get; set; }


		public List<SelectListItem> UserTypeList { get; set; }
		public VehicleFeaturesForCache VehicleFeaturesForCache { get; set; }
	}
}
