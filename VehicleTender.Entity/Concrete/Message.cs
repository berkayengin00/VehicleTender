using System;

namespace VehicleTender.Entity.Concrete
{
    public class Message:BaseEntity
    {
        public string MessageTitle { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
    }
}
