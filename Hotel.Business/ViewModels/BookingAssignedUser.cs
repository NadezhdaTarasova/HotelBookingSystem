﻿using System;

namespace Business.ViewModels
{
    public class BookingAssignedUser
    {
        public Guid BookingId { get; set; }

        public Guid PersonId { get; set; }

        public Booking Booking { get; set; }

        public User User { get; set; }
    }
}
