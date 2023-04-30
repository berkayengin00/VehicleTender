using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Result;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.RetailCustomer;

namespace VehicleTender.DAL.Concrete
{
	public class RetailCustomerDal : CrudRepository<RetailCustomer>
	{
		public RetailCustomerDal() : base(new EfVehicleTenderContext())
		{
		}


		public int Add(RetailCustomerAddVM vm)
		{
			return base.Insert(new RetailCustomer()
			{
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				CreatedBy = vm.CreatedBy,
				CreatedDate = vm.AddedDate,
				Email = vm.Email,
				IsActive = true,
				IsVerify = true,
				PasswordHash = vm.PasswordHash,
				PhoneNumber = vm.PhoneNumber,
				UpdatedBy = vm.UpdatedBy,
				UpdatedDate = vm.UpdatedDate,
			});
		}

		// todo bu neden kullanılmadı
		public List<RetailCustomerVMForAdmin> GetAllCustomerForAdmin()
		{
			List<RetailCustomerVMForAdmin> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = db.RetailCustomers.Select(x => new RetailCustomerVMForAdmin()
				{
					UserId = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					Email = x.Email,
					PhoneNumber = x.PhoneNumber,
					IsActive = x.IsActive,
					IsVerify = x.IsVerify,
				}).ToList();
			}
			return list;
		}

		public Result<RetailCustomerUpdateVM> GetUserByUserId(int userId)
		{
			RetailCustomerUpdateVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from user in db.RetailCustomers
						  where userId == user.Id
						  select new RetailCustomerUpdateVM()
						  {
							  LastName = user.LastName,
							  PhoneNumber = user.PhoneNumber,
							  Email = user.Email,
							  PasswordHash = user.PasswordHash,
							  PasswordHashAgain = user.PasswordHash,
							  IsVerify = user.IsVerify,
							  IsActive = user.IsActive,
							  CreatedBy = user.CreatedBy,
							  UpdatedBy = user.UpdatedBy,
							  AddedDate = user.CreatedDate,
							  UpdatedDate = user.UpdatedDate,
							  FirstName = user.FirstName,
						  }).SingleOrDefault();
			}

			return new Result<RetailCustomerUpdateVM>(result != null ? "Data Geldi" : "Boş", result, result != null ? true : false);
		}

		public bool Update(RetailCustomerUpdateVM vm)
		{
			RetailCustomer result = Get(x => x.Id == vm.UserId);
			if (result != null)
			{
				result.FirstName = vm.FirstName;
				result.LastName = vm.LastName;
				result.PhoneNumber = vm.PhoneNumber;
				result.Email = vm.Email;
				result.PasswordHash = vm.PasswordHash;
				result.UpdatedBy = vm.UpdatedBy;
				result.UpdatedDate = vm.UpdatedDate;
				result.IsActive = vm.IsActive;
				result.IsVerify = vm.IsVerify;
				result.CreatedDate = vm.AddedDate;
				result.CreatedBy = vm.CreatedBy;
				
			}
			return Save() > 0;
		}

		public List<SelectListItem> GetUsersForDropdown()
		{
			return Select( x=> new SelectListItem()
			{
				Text = $"{x.FirstName} {x.LastName}",
				Value = x.Id.ToString()
			});
		}

		public int SoftDelete(int userId)
		{
			RetailCustomer result = Get(x => x.Id == userId);
			if (result != null)
			{
				result.IsActive = false;
			}
			return Save();
		}
	}
}
