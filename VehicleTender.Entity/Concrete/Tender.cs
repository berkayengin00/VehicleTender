using System;

namespace VehicleTender.Entity.Concrete
{
    public class Tender : BaseEntity
    {
        public string TenderName { get; set; }
        public int TenderStatusId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TenderTypeId { get; set; }// todo Kurumsal mi Bİreysel mi Ayrı tablo daha mantıklı onun id si verilebilir
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        
        public TenderStatus TenderStatus { get; set; }
        public UserType TenderType { get; set; }
    }
}
