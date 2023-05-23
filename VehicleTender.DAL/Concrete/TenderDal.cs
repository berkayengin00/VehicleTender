using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VehicleTender.DAL.CrudRepository;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View;
using VehicleTender.Entity.View.DB;

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
					base.Insert(tender);
					new TenderDetailDal().Insert(vm.tenderDetailList.Select(x => new TenderDetail()
					{
						MinPrice = x.MinPrice,
						StartPrice = x.StartPrice,
						TenderId = tender.Id,
						VehicleId = x.VehicleId,
					}).ToList());
					base.Save();
					tran.Complete();
				}// todo log yapılınca dispose edilmeden önce log alınacak
				catch
				{
					tran.Dispose();
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
			Tender tender = Get(x=>x.Id==tenderId);
			if (tender !=null)
			{
				tender.IsActive = false;
			}
			return Save();
		}
	}
}
