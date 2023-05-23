using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class CommissionFeeDal
	{


		/// <summary>
		/// Noter Ücretleri Aktif olanlar geitirilir.
		/// </summary>
		/// <returns></returns>
		public DataResult<List<CommissionFeeVM>> GetAll()
		{
			List<CommissionFeeVM> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from commissionfee in db.CommissionFees
						where commissionfee.IsActive == true
						select new CommissionFeeVM()
						{
							Id = commissionfee.Id,
							StartDate = commissionfee.StartDate,
							EndDate = commissionfee.EndDate,
							Fee = commissionfee.Fee,
							VehicleMinPrice = commissionfee.VehicleMinPrice,
							VehicleMaxPrice = commissionfee.VehicleMaxPrice,
						}).ToList();
			}

			return new DataResult<List<CommissionFeeVM>>(list != null ? "Noter Ücretleri Getirildi" : "Hata!", list, list != null);
		}

		/// <summary>
		/// CommissionFee ekler geriye Result döner.
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		public Result Add(CommissionFeeVM vm)
		{
			int result = 0;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{

				// todo buraya gelmeden önce giriş tarihi bitiş tarhinden küçük mü kontrolü yapılamlı - validasyon

				if (CheckDate(db.CommissionFees.ToList(), vm.StartDate))
				{
					db.CommissionFees.Add(new CommissionFee()
					{
						StartDate = vm.StartDate,
						EndDate = vm.EndDate,
						Fee = vm.Fee,
						IsActive = vm.IsActive,
						VehicleMinPrice = vm.VehicleMinPrice,
						VehicleMaxPrice = vm.VehicleMaxPrice,
					});
					result = db.SaveChanges();
				}
			}
			return new Result(result > 0 ? "Noter Ücreti Eklendi" : "Hata", result > 0);
		}

		/// <summary>
		/// Ayni tarih araliginda kayit var mi kontrol edilir.
		/// Eğer Aktif olan bir kayit varsa yeni kayit eklenemez.
		/// </summary>
		/// <returns></returns>
		public bool CheckDate(List<CommissionFee> list, DateTime startDate)
		{
			foreach (var item in list)
			{
				// db deki bitiş tarihinden küçük bir girilen değer(vm) tarihi varsa false
				if (startDate < item.EndDate && item.IsActive==true)
				{
					return false;
				}
			}

			return true;
		}

		public DataResult<CommissionFeeVM> GetById(int id)
		{
			CommissionFeeVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = db.CommissionFees.Select(x => new CommissionFeeVM()
				{
					Id = x.Id,
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					Fee = x.Fee,
					IsActive = x.IsActive,
					VehicleMinPrice = x.VehicleMinPrice,
					VehicleMaxPrice = x.VehicleMaxPrice
				}).SingleOrDefault(x => x.Id == id);
			}
			return new DataResult<CommissionFeeVM>(result != null ? "Noter Ücreti Getirildi" : "Hata!", result, result != null);
		}
	}
}
