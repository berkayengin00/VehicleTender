using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.DAL.Result;
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

		public int Add(CorporateCustomerAddVM vm)
		{
			return base.Insert(new CorporateCustomer()
			{
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				CompanyType = vm.CompanyType,
				CompanyName = vm.CompanyName,
				CreatedBy = vm.CreatedBy,
				CreatedDate = vm.AddedDate,
				District = vm.District,
				Email = vm.Email,
				IsActive = vm.IsActive,
				IsVerify = vm.IsVerify,
				Neighbourhood = vm.Neighbourhood,
				PasswordHash = vm.PasswordHash,
				PhoneNumber = vm.PhoneNumber,
				Province = vm.Province,
				UpdatedBy = vm.UpdatedBy,
				UpdatedDate = vm.UpdatedDate,
				CorporatePackageId = vm.CorporatePackageId
			});
		}

		public List<CorporateCustomerListVMForAdmin> GetAllForAdmin()
		{
			List<CorporateCustomerListVMForAdmin> result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from user in db.CorporateCustomers
							  join package in db.CorporatePackages on user.CorporatePackageId equals package.Id
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
								  Province = user.Province,
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
		public Result<CorporateCustomerUpdateVM> GetUserByUserId(int userId)
		{
			CorporateCustomerUpdateVM result = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				result = (from c in db.CorporateCustomers
						  where c.Id == userId
						  select new CorporateCustomerUpdateVM()
						  {
							  UserId = c.Id,
							  FirstName = c.FirstName,
							  LastName = c.LastName,
							  CompanyType = c.CompanyType,
							  CompanyName = c.CompanyName,
							  District = c.District,
							  Email = c.Email,
							  IsActive = c.IsActive,
							  IsVerify = c.IsVerify,
							  Neighbourhood = c.Neighbourhood,
							  PhoneNumber = c.PhoneNumber,
							  Province = c.Province,
							  UpdatedBy = c.UpdatedBy,
							  UpdatedDate = c.UpdatedDate,
							  AddedDate = c.CreatedDate,
							  CreatedBy = c.CreatedBy,
							  PasswordHash = c.PasswordHash

						  }).SingleOrDefault();
			}
			return new Result<CorporateCustomerUpdateVM>(result != null ? "Kullanıcı Mevcut" : "Boş", result, result != null);
		}

		public bool Update(CorporateCustomerUpdateVM vm)
		{
			var corporateCustomer = base.Get(x => x.Id == vm.UserId);
			if (corporateCustomer != null)
			{
				corporateCustomer.Province = vm.Province;
				corporateCustomer.Neighbourhood = vm.Neighbourhood;
				corporateCustomer.District = vm.District;
				corporateCustomer.PhoneNumber = vm.PhoneNumber;
				corporateCustomer.IsActive = vm.IsActive;
				corporateCustomer.IsVerify = vm.IsVerify;
				corporateCustomer.UpdatedBy = vm.UpdatedBy;
				corporateCustomer.UpdatedDate = vm.UpdatedDate;
				corporateCustomer.PasswordHash = vm.PasswordHash;
				corporateCustomer.CompanyType = vm.CompanyType;
				corporateCustomer.CompanyName = vm.CompanyName;
				corporateCustomer.LastName = vm.LastName;
				corporateCustomer.FirstName = vm.FirstName;
				corporateCustomer.Email = vm.Email;
				corporateCustomer.CreatedBy = vm.CreatedBy;
				corporateCustomer.CreatedDate = vm.AddedDate;
			}
			return Save() > 0;

		}

		public int SoftDelete(int id)
		{
			var corporateCustomer = base.Get(x => x.Id == id);
			if (corporateCustomer != null)
			{
				corporateCustomer.IsActive = false;
			}
			return Save();
		}

		public void UpdateIsVerify(int id)
		{
			var corporateCustomer = base.Get(x => x.Id == id);
			corporateCustomer.IsVerify = true;
			Save();
		}

		/// <summary>
		/// Kurumsal Müşterinin Paketini Günceller.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="packageId"></param>
		public void UpdatePackage(int id,int packageId)
		{
			var user = base.Get(x => x.Id == id);
			user.CorporatePackageId = packageId;
			Save();
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
