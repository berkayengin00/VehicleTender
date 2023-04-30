using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.EFConfiguraitons;
using VehicleTender.DAL.Result;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class LoginDal
	{

		public DataResult<SessionVMForAdmin> CheckAdmin(LoginVM vm)
		{
			SessionVMForAdmin admin = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				admin = (from user in db.Users
					join roleUser in db.RoleUsers on user.Id equals roleUser.UserId
					join role in db.Roles on roleUser.RoleId equals role.Id
					where user.Email == vm.Email && user.PasswordHash == vm.Password
					select new SessionVMForAdmin
					{
						Email = user.Email,
						AdminId = user.Id,
						Roles = db.Roles.Where(x=>x.Id==role.Id).ToList(),
						Menus = (from menu in db.Menus
								join menuRole in db.RoleMenus on menu.Id equals menuRole.MenuId
								 where menuRole.RoleId == role.Id select menu).ToList()
					}).SingleOrDefault();


				//admin = db.Users.Where(x => x.Email == vm.Email && x.PasswordHash == vm.Password).Select(x => new SessionVMForAdmin() { AdminId = x.Id, Email = x.Email }).SingleOrDefault();
			}

			return new DataResult<SessionVMForAdmin>(admin !=null ?"Admin Getirildi" :"Kayıtlı Admin yok", admin, admin == null ? false : true);

		}
	}
}
