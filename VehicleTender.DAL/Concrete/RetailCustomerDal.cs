using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Results;
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


		public Result Add(RetailCustomerAddVM vm)
		{
			int result;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				db.RetailCustomers.Add( new RetailCustomer()
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

				result = db.SaveChanges();
			}
			//base.Insert(new RetailCustomer()
			//{
			//	FirstName = vm.FirstName,
			//	LastName = vm.LastName,
			//	CreatedBy = vm.CreatedBy,
			//	CreatedDate = vm.AddedDate,
			//	Email = vm.Email,
			//	IsActive = true,
			//	IsVerify = true,
			//	PasswordHash = vm.PasswordHash,
			//	PhoneNumber = vm.PhoneNumber,
			//	UpdatedBy = vm.UpdatedBy,
			//	UpdatedDate = vm.UpdatedDate,
				
			//});
			//int result = Save();
			return new Result(result>0 ? "Bireysel Müşteri Eklendi" : "Hata",result>0);
		}

		// todo bu neden kullanılmadı
		public DataResult<List<RetailCustomerVMForAdmin>> GetAllCustomerForAdmin()
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
					CreatedDate = x.CreatedDate
				}).ToList();
			}
			return new DataResult<List<RetailCustomerVMForAdmin>>(list != null ? "Data Geldi" : "Hata!", list, list != null);
		}

		public DataResult<RetailCustomerUpdateVM> GetUserByUserId(int userId)
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

			return new DataResult<RetailCustomerUpdateVM>(result != null ? "Kullanıcı Getirildi" : "Boş", result, result != null);
		}

		public Result Update(RetailCustomerUpdateVM vm)
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

			int res = Save();
			return new Result(res > 0 ? "Bireysel Müşteri Eklendi" : "Hata", res > 0);
		}

		public DataResult<List<SelectListItem>> GetUsersForDropdown()
		{

			List<SelectListItem> list= Select( x=> new SelectListItem()
			{
				Text = $"{x.FirstName} {x.LastName}",
				Value = x.Id.ToString()
			});
			return new DataResult<List<SelectListItem>>(list!=null ?"Kullanıcı Listesi Geldi":"Hata!",list,list!=null);
		}

		public Result SoftDelete(int userId)
		{
			RetailCustomer result = Get(x => x.Id == userId);
			if (result != null)
			{
				result.IsActive = false;
			}
			int res = Save();
			return new Result(res>0 ? "Bireysel Müşteri Silindi" : "Hata",res>0);
		}
	}
}
