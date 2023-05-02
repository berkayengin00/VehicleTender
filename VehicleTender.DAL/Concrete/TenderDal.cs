using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;
using VehicleTender.Entity.View.Tender;

namespace VehicleTender.DAL.Concrete
{
	public class TenderDal : CrudRepository<Tender>
	{
		public TenderDal() : base(new EfVehicleTenderContext())
		{
		}

		public void AddTender(TenderAndTenderDetailVmForAdmin vm)
		{
			using (TransactionScope tran = new TransactionScope())
			{
				using (EfVehicleTenderContext db = new EfVehicleTenderContext())
				{
					try
					{
						Tender tender = new Tender()
						{
							TenderName = vm.TenderAddVmForAdmin.TenderName,
							StartDateTime = vm.TenderAddVmForAdmin.StartDateTime,
							EndDateTime = vm.TenderAddVmForAdmin.EndDateTime,
							CreatedDate = vm.TenderAddVmForAdmin.StartDateTime,
							UpdatedDate = vm.TenderAddVmForAdmin.ModefieDateTime,
							IsActive = vm.TenderAddVmForAdmin.IsActive,
							TenderTypeId = vm.TenderAddVmForAdmin.TenderTypeId,
							TenderStatusId = vm.TenderAddVmForAdmin.TenderStatusId,
							CreatedBy = vm.TenderAddVmForAdmin.CreatedById,
							UpdatedBy = vm.TenderAddVmForAdmin.UpdatedById,

						};
						db.Tenders.Add(tender);

						db.TenderDetails.AddRange(vm.tenderDetailList.Select(x => new TenderDetail()
						{
							MinPrice = x.MinPrice,
							StartPrice = x.StartPrice,
							TenderId = tender.Id,
							VehicleId = x.VehicleId,
						}));
						//new TenderDetailDal().Insert(vm.tenderDetailList.Select(x => new TenderDetail()
						//{
						//	MinPrice = x.MinPrice,
						//	StartPrice = x.StartPrice,
						//	TenderId = tender.Id,
						//	VehicleId = x.VehicleId,
						//}).ToList());
						db.SaveChanges();
						tran.Complete();
					}// todo log yapılınca dispose edilmeden önce log alınacak
					catch
					{
						tran.Dispose();
					}
				}
				
			}
		}

		public List<TenderListVMForAdmin> GetAll()
		{
			List<TenderListVMForAdmin> list = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				list = (from tender in db.Tenders
						join tenderType in db.TenderTypes on tender.TenderTypeId equals tenderType.Id
						join tenderStatus in db.TenderStatus on tender.TenderStatusId equals tenderStatus.Id
						select new TenderListVMForAdmin()
						{
							TenderId = tender.Id,
							EndDateTime = tender.EndDateTime,
							StartDateTime = tender.StartDateTime,
							TenderName = tender.TenderName,
							TenderStatusName = tenderStatus.Name,
							TenderTypeName = tenderType.Name,
							IsActive = tender.IsActive,
						}).ToList();
			}
			return list;
		}

		public int SoftDelete(int tenderId)
		{
			Tender tender = Get(x => x.Id == tenderId);
			if (tender != null)
			{
				tender.IsActive = false;
			}
			return Save();
		}

		public TenderUpdateVMForAdmin GetTenderById(int tenderId)
		{
			TenderUpdateVMForAdmin vm = null;
			using (EfVehicleTenderContext db = new EfVehicleTenderContext())
			{
				vm = (from tender in db.Tenders
					  where tender.Id == tenderId
					  select new TenderUpdateVMForAdmin()
					  {
						  EndDateTime = tender.EndDateTime,
						  StartDateTime = tender.StartDateTime,
						  TenderName = tender.TenderName,
						  TenderStatusId = tender.TenderStatusId,
						  TenderTypeId = tender.TenderTypeId,
						  IsActive = tender.IsActive,
						  AddedDateTime = tender.CreatedDate,
						  ModefieDateTime = tender.UpdatedDate,
						  UpdatedById = tender.UpdatedBy,
						  TenderDetailList = db.TenderDetails.Where(x=>x.TenderId==tenderId).Select(x=> new TenderDetailVM(){TenderDetailId = x.Id,VehicleId = x.VehicleId,MinPrice = x.MinPrice,StartPrice = x.MinPrice}).ToList(),
						  TenderTypes = db.TenderTypes.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),
						  TenderStatusList = db.TenderStatus.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList(),

					  }).SingleOrDefault();
			}

			return vm;
		}
	}
}
