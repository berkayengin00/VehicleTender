using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class BrandDal:CrudRepository<Brand>
	{
		public BrandDal() : base(new EfVehicleTenderContext())
		{
		}

		public List<SelectListItem> GetAllBrand()
		{
			List<SelectListItem> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = db.Brands.Select(x => new SelectListItem()
				{
					Value = x.Id.ToString(),
					Text = x.BrandName
				}).ToList();
			}
			return list;
		}
	}
}
