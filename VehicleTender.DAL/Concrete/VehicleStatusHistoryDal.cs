using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleStatusHistoryDal:CrudRepository<VehicleStatusHistory>
	{
		public VehicleStatusHistoryDal() : base(new EfVehicleTenderContext())
		{
		}


		/// <summary>
		/// Araçta son statü değişikliği dışında bir değiklik olursa bu metod update eder
		/// Eğer son statü değişikliği aynı ise hiç bir işlem yapmaz
		/// Eğer son statü değişikliği aynı ise yani başka bir işlem yapılmamışsa false döner
		/// </summary>
		/// <param name="vehicleId"></param>
		/// <param name="statusId"></param>
		public bool CheckVehicleStatus(int vehicleId,int statusId)
		{
			int result = 0;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from vsh in db.VehicleStatusHistories
				where vsh.VehicleId == vehicleId && vsh.VehicleStatusId==statusId
				orderby vsh.StatusChangeDate descending
				select vsh.VehicleStatusId).SingleOrDefault();
			}
			return (result != statusId); // Eğer son statü değişikliği aynı ise yani başka bir işlem yapılmamışsa false döner
		}
	}
}
