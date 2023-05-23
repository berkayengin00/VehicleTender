﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class TenderDetailDal:CrudRepository<TenderDetail>
	{
		public TenderDetailDal() : base(new EfVehicleTenderContext())
		{
		}


	}
}
