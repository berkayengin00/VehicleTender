using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Employee;

namespace VehicleTender.DAL.Concrete
{
	public class EmployeeDal : CrudRepository<Employee>
	{
		public EmployeeDal() : base(new EfVehicleTenderContext())
		{
		}


		public void Add(EmployeeAddVM vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (EfVehicleTenderContext db = new EfVehicleTenderContext())
				{
					try
					{
						int userId = db.Employees.Add(new Employee()
						{
							UserName = vm.UserName,
							PasswordHash = vm.PasswordHash,
							FirstName = vm.FirstName,
							LastName = vm.LastName,
							Email = vm.Email,
							PhoneNumber = vm.PhoneNumber,
							IsActive = vm.IsActive,
							CreatedBy = vm.CreatedBy,
							CreatedDate = vm.AddedDate,
							UpdatedBy = vm.UpdatedBy,
							UpdatedDate = vm.UpdatedDate,
							IsVerify = vm.IsVerify,
						}).Id;

						db.RoleUsers.Add(new RoleUser()
						{
							RoleId = vm.RoleId,
							UserId = userId
						});
						db.SaveChanges();
						tran.Complete();
					}
					catch (Exception e)
					{
						tran.Dispose();
						//todo log al
						throw;
					}
				}

			}


		}

		public void Update(EmployeeAddVM vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (EfVehicleTenderContext db = new EfVehicleTenderContext())
				{
					try
					{
						var result = Get(x => x.Id == vm.EmployeeId);
						if (result != null)
						{
							result.Id = vm.EmployeeId;
							result.UserName = vm.UserName;
							result.PasswordHash = vm.PasswordHash;
							result.FirstName = vm.FirstName;
							result.LastName = vm.LastName;
							result.Email = vm.Email;
							result.PhoneNumber = vm.PhoneNumber;
							result.IsActive = vm.IsActive;
							result.CreatedBy = vm.CreatedBy;
							result.CreatedDate = vm.AddedDate;
							result.UpdatedBy = vm.UpdatedBy;
							result.UpdatedDate = vm.UpdatedDate;
							result.IsVerify = vm.IsVerify;
						}


						RoleUser roleuser = db.RoleUsers.SingleOrDefault(x => x.UserId == vm.EmployeeId);
						db.Entry(roleuser).State = EntityState.Deleted;

						if (roleuser != null)
						{
							db.RoleUsers.Remove(roleuser);
						}



						db.RoleUsers.Add(new RoleUser() { RoleId = vm.RoleId, UserId = vm.EmployeeId });
						db.SaveChanges();
						tran.Complete();
					}
					catch (Exception e)
					{
						tran.Dispose();	
						throw;
					}

				}
			}





		}

		public List<EmployeeListVM> GetAll()
		{
			List<EmployeeListVM> result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from user in db.Employees
						  join roleUser in db.RoleUsers on user.Id equals roleUser.UserId
						  join role in db.Roles on roleUser.RoleId equals role.Id
						  select new EmployeeListVM()
						  {
							  EmployeeId = user.Id,
							  UserName = user.UserName,
							  FirstName = user.FirstName,
							  LastName = user.LastName,
							  Email = user.Email,
							  PhoneNumber = user.PhoneNumber,
							  IsActive = user.IsActive,
							  RoleName = role.RoleName
						  }).ToList();
			}
			return result;
		}

		public EmployeeAddVM Get(int id)
		{
			EmployeeAddVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from user in db.Employees
						  join roleUser in db.RoleUsers on user.Id equals roleUser.UserId
						  join role in db.Roles on roleUser.RoleId equals role.Id
						  where user.Id == id
						  select new EmployeeAddVM()
						  {
							  EmployeeId = user.Id,
							  UserName = user.UserName,
							  PasswordHash = user.PasswordHash,
							  FirstName = user.FirstName,
							  LastName = user.LastName,
							  Email = user.Email,
							  PhoneNumber = user.PhoneNumber,
							  IsActive = user.IsActive,
							  CreatedBy = user.CreatedBy,
							  AddedDate = user.CreatedDate,
							  UpdatedBy = user.UpdatedBy,
							  UpdatedDate = user.UpdatedDate,
							  IsVerify = user.IsVerify,
							  RoleId = role.Id
						  }).SingleOrDefault();
			}
			return result;
		}

		public DataResult<int> SoftDelete(int id)
		{
			Get(x => x.Id == id).IsActive = false;
			int result = Save();
			return new DataResult<int>
			(
				 result > 0 ? "Silme işlemi başarılı" : "Silme işlemi başarısız", 0, result > 0
			);
		}
	}
}
