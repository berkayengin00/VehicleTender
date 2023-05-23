using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Hashing;
using VehicleTender.DAL.Results;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.CorporateCustomer;
using VehicleTender.Entity.View.RetailCustomer;

namespace VehicleTender.DAL.Concrete
{
	public class CorporateCustomerDal : CrudRepository<CorporateCustomer>
	{
		public CorporateCustomerDal() : base(new EfVehicleTenderContext())
		{
		}


		public Result Add(CorporateCustomerAddVM vm)
		{
			var result= base.Insert(new CorporateCustomer()
			{
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				CompanyType = vm.CompanyType,
				CompanyName = vm.CompanyName,
				CreatedBy = vm.CreatedBy,
				CreatedDate = vm.AddedDate,
				DistrictId = vm.District,
				Email = vm.Email,
				IsActive = vm.IsActive,
				IsVerify = vm.IsVerify,
				Neighbourhood = vm.Neighbourhood,
				PasswordHash = new MyHash().HashPassword(vm.PasswordHash),
				PhoneNumber = vm.PhoneNumber,
				UpdatedBy = vm.UpdatedBy,
				UpdatedDate = vm.UpdatedDate,
				CorporatePackageId = vm.CorporatePackageId,
				
			});

			return new Result(result > 0 ? "Kurumsal Müşteri Eklendi" : "Hata", result > 0);
		}

		public List<CorporateCustomerListVMForAdmin> GetAllForAdmin()
		{
			List<CorporateCustomerListVMForAdmin> result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from user in db.CorporateCustomers
							  join package in db.CorporatePackages on user.CorporatePackageId equals package.Id
							  where user.IsActive
							  select new CorporateCustomerListVMForAdmin()
							  {
								  CompanyName = user.CompanyName,
								  CompanyType = user.CompanyType,
								  Email = user.Email,
								  FirstName = user.FirstName,
								  LastName = user.LastName,
								  PhoneNumber = user.PhoneNumber,
								  IsActive = user.IsActive,
								  IsVerify = user.IsVerify,
								  Id = user.Id,
								  AddedDate = user.CreatedDate,
								  District = db.District.FirstOrDefault(x=>x.Id==user.DistrictId).Name,
								  PackageName = package.PackageName,
								  PackageId = package.Id
							  }).ToList();
			}
			return result;
		}

		public List<SelectListItem> GetAllCompanyName()
		{
			return base.Select(x => new SelectListItem()
			{
				Text = x.CompanyName,
				Value = x.Id.ToString()
			});
		}
		/// <summary>
		/// Result ın datası CorporateCustomerUpdateVM tipinde olacak.
		/// Geriye id bilgisene göre kullanıcı bilgilerini döndürür.
		/// Kurumsal Müşteri Güncelleme sayfasında kullanılır.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public DataResult<CorporateCustomerUpdateVM> GetUserByUserId(int userId)
		{
			CorporateCustomerUpdateVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from c in db.CorporateCustomers
					join d in db.District on c.DistrictId equals d.Id
					where c.Id == userId
						  select new CorporateCustomerUpdateVM()
						  {
							  UserId = c.Id,
							  FirstName = c.FirstName,
							  LastName = c.LastName,
							  CompanyType = c.CompanyType,
							  CompanyName = c.CompanyName,
							  DistrictId = c.DistrictId,
							  Email = c.Email,
							  IsActive = c.IsActive,
							  IsVerify = c.IsVerify,
							  Neighbourhood = c.Neighbourhood,
							  PhoneNumber = c.PhoneNumber,
							  ProvinceId = d.ProvinceId,
							  UpdatedBy = c.UpdatedBy,
							  UpdatedDate = c.UpdatedDate,
							  AddedDate = c.CreatedDate,
							  CreatedBy = c.CreatedBy,
							  PasswordHash = c.PasswordHash

						  }).SingleOrDefault();
			}
			return new DataResult<CorporateCustomerUpdateVM>(result != null ? "Kullanıcı Mevcut" : "Boş", result, result != null);
		}

		public Result Update(CorporateCustomerUpdateVM vm)
		{
			var corporateCustomer = base.Get(x => x.Id == vm.UserId);
			if (corporateCustomer != null)
			{
				corporateCustomer.DistrictId = vm.DistrictId;
				corporateCustomer.Neighbourhood = vm.Neighbourhood;
				corporateCustomer.PhoneNumber = vm.PhoneNumber;
				corporateCustomer.IsActive = vm.IsActive;
				corporateCustomer.IsVerify = vm.IsVerify;
				corporateCustomer.UpdatedBy = vm.UpdatedBy;
				corporateCustomer.UpdatedDate = vm.UpdatedDate;
				corporateCustomer.PasswordHash = corporateCustomer.PasswordHash;
				corporateCustomer.CompanyType = vm.CompanyType;
				corporateCustomer.CompanyName = vm.CompanyName;
				corporateCustomer.LastName = vm.LastName;
				corporateCustomer.FirstName = vm.FirstName;
				corporateCustomer.Email = vm.Email;
				corporateCustomer.CreatedBy = vm.CreatedBy;
				corporateCustomer.CreatedDate = vm.AddedDate;
			}
			var result= Save();
			return new Result(result > 0 ? "Kurumsal Müşteri Güncellendi" : "Hata", result > 0);

		}

		public Result SoftDelete(int id)
		{
			var corporateCustomer = base.Get(x => x.Id == id);
			if (corporateCustomer != null)
			{
				corporateCustomer.IsActive = false;
			}
			var result= Save();
			return new Result(result > 0 ? "Kurumsal Müşteri Silindi" : "Hata", result > 0);	
		}

		public Result UpdateIsVerify(int id)
		{
			var corporateCustomer = base.Get(x => x.Id == id);
			corporateCustomer.IsVerify = true;
			var result = Save();
			return new Result(result > 0 ? "Kurumsal Müşteri Onaylandı" : "Hata", result > 0);
		}

		/// <summary>
		/// Kurumsal Müşterinin Paketini Günceller.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="packageId"></param>
		public Result UpdatePackage(int id,int packageId)
		{
			var user = base.Get(x => x.Id == id);
			user.CorporatePackageId = packageId;
			var result = Save();
			return new Result(result > 0 ? "Kurumsal Müşteri Paketi Güncellendi" : "Hata", result > 0);
		}

		public List<SelectListItem> GetUsersForDropdown()
		{
			return Select(x => new SelectListItem
			{
				Text = x.CompanyName,
				Value = x.Id.ToString()
			});
		}
	}
}
