using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class NotaryFeeDal
	{
		/// <summary>
		/// Noter Ücretleri Aktif olanlar geitirilir.
		/// </summary>
		/// <returns></returns>
		public DataResult<List<NotaryFeeVM>> GetAll()
		{
			List<NotaryFeeVM> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from notaryFee in db.NotaryFees
						where notaryFee.IsActive == true
						select new NotaryFeeVM()
						{
							Id = notaryFee.Id,
							StartDate = notaryFee.StartDate,
							EndDate = notaryFee.EndDate,
							Fee = notaryFee.Fee,
						}).ToList();
			}

			return new DataResult<List<NotaryFeeVM>>(list != null ? "Noter Ücretleri Getirildi" : "Hata!", list, list != null);
		}

		public Result Add(NotaryFeeVM vm)
		{
			int result = 0;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				
				// todo buraya gelmeden önce giriş tarihi bitiş tarhinden küçük mü kontrolü yapılamlı - validasyon

				if (CheckDate(db.NotaryFees.ToList(), vm.StartDate))
				{
					db.NotaryFees.Add(new NotaryFee()
					{
						StartDate = vm.StartDate,
						EndDate = vm.EndDate,
						Fee = vm.Fee,
						IsActive = vm.IsActive
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
		public bool CheckDate(List<NotaryFee> list,DateTime startDate)
		{
			foreach (var item in list)
			{
				// db deki bitiş tarihinden küçük bir girilen değer(vm) tarihi varsa false
				if (startDate<item.EndDate && item.IsActive == true)
				{
					return false;
				}
			}

			return true;
		}

		public DataResult<NotaryFeeVM> GetById(int id)
		{
			NotaryFeeVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = db.NotaryFees.Select(x=>new NotaryFeeVM()
				{
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					Fee = x.Fee,
				}).SingleOrDefault(x=>x.Id==id);
			}
			return new DataResult<NotaryFeeVM>(result!=null?"Noter Ücreti Getirildi":"Hata!",result,result!=null);
		}
	}
}
