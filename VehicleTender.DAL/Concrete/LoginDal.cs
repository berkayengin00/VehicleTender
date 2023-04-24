using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Result;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class LoginDal
	{

		public Result<SessionVMForAdmin> CheckAdmin(LoginVM vm)
		{
			SessionVMForAdmin admin = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				var result = (from user in db.Users
					join roleUser in db.RoleUsers on user.Id equals roleUser.UserId
					join role in db.Roles on roleUser.RoleId equals role.Id
					where user.Email == vm.Email && user.PasswordHash == vm.Password
					group role by user into g
					select new SessionVMForAdmin
					{
						Email = g.Key.Email,
						AdminId = g.Key.Id,
						Roles = g.ToList()
					}).ToList();


				//admin = db.Users.Where(x => x.Email == vm.Email && x.PasswordHash == vm.Password).Select(x => new SessionVMForAdmin() { AdminId = x.Id, Email = x.Email }).SingleOrDefault();
			}

			return new Result<SessionVMForAdmin>(admin !=null ?"Admin Getirildi" :"Kayıtlı Admin yok", admin, admin == null ? false : true);

		}
	}
}
