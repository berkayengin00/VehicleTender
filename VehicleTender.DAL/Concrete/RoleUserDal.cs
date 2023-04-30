using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Concrete
{
	public class RoleUserDal:CrudRepository<RoleUser>
	{
		public RoleUserDal() : base(new EfVehicleTenderContext())
		{
		}


		public void AddRoleUser(RoleUser vm)
		{
			Insert(vm,false);
		}
	}
}
