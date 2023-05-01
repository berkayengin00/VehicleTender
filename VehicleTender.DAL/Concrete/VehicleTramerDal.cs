using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.View.Tramer;

namespace VehicleTender.DAL.Concrete
{
	public class VehicleTramerDal
	{

		public DataResult<List<TramerListVM>> GetAllByVehicleId(int id)
		{
			List<TramerListVM> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from vehicleTramer in db.VehicleTramers
					   join tramer in db.Tramers on vehicleTramer.TramerId equals tramer.Id
					   join vehiclePartStatus in db.VehiclePartStatus on vehicleTramer.VehiclePartStatusId equals vehiclePartStatus.Id
						where vehicleTramer.VehicleId == id
					   select new TramerListVM()
					   {
						   PartName = vehiclePartStatus.Name,
						   TramerName = tramer.TramerName,
						   PartPrice = vehicleTramer.PartPrice,
					   }).ToList();
			}

			return new DataResult<List<TramerListVM>>(list!=null  ? "Tramer Bilgileri Getirildi":"Hata!",list,list!=null);
		}
	}
}
