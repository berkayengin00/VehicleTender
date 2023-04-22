using System;

namespace VehicleTender.Entity.Concrete
{
    public class Tender : BaseEntity
    {
        public int VehicleId { get; set; }
        public int TenderStatusId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool TenderType { get; set; }// Kurumsal mi Bİreysel mi Ayrı tablo daha mantıklı onun id si verilebilir
        public decimal StartPrice { get; set; }
        public decimal MinPrice { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public TenderStatus TenderStatus { get; set; }

    }
}
