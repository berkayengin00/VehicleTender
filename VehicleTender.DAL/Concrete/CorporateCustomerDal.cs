using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class CorporateCustomerDal:CrudRepository<CorporateCustomer>
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
				CreatedBy = 1,
				CreatedDate = DateTime.Now,
				District = vm.District,
				Email = vm.Email,
				IsActive = true,
				IsVerify = true,
				Neighbourhood = vm.Neighbourhood,
				PasswordHash = vm.PasswordHash,
				PhoneNumber = vm.PhoneNumber,
				Province = vm.Province,
				UpdatedBy = 1,
				UpdatedDate = DateTime.Now,
				UserType = 1,

			});
		}
	}
}
