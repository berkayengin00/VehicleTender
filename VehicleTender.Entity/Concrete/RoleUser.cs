﻿namespace VehicleTender.Entity.Concrete
{
    // ara tablo
    public class RoleUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}
