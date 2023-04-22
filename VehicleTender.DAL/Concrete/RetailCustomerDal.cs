﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;

namespace VehicleTender.DAL.Concrete
{
	public class RetailCustomerDal:CrudRepository<RetailCustomer>
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
				CreatedBy = 1,
				CreatedDate = DateTime.Now,
				Email = vm.Email,
				IsActive = true,
				IsVerify = true,
				PasswordHash = vm.PasswordHash,
				PhoneNumber = vm.PhoneNumber,
				UpdatedBy = 1,
				UpdatedDate = DateTime.Now,
				UserType = 1
			});
		}

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

	}
}