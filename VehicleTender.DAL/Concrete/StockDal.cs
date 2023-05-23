using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View.Stock;

namespace VehicleTender.DAL.Concrete
{
	public class StockDal:CrudRepository<Stock>
	{
		public StockDal() : base(new EfVehicleTenderContext())
		{
		}

		/// <summary>
		/// Plazadaki araçlar için stok listesi
		/// </summary>
		/// <returns></returns>
		public List<StockVMForAdmin> GetAllForAdmin()
		{
			List<StockVMForAdmin> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from stock in db.Stocks 
						join vehicle in db.Vehicles on stock.VehicleId equals vehicle.Id
						where stock.UserTypeId == (int)UserTypeEnum.Plaza
						select new StockVMForAdmin()
						{
							LicensePlate = vehicle.LicensePlate,
							AddedDate = stock.CreatedDate,
							AddedPrice = stock.AddedPrice,
							PreliminaryValuationPrice = stock.PreliminaryValuationPrice
						}).ToList();
			}
			return list;
		}
	}
}
