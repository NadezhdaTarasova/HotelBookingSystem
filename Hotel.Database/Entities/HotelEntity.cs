﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Database.Entities;

namespace HotelBookingSystem.Models
{
    public class HotelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassId { get; set; }

        public string StarsCount { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string StreetId { get; set; }

        public string BuildingNumber { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsFreeRooms { get; set; }

        public HotelClassEntity HotelClass { get; set; }

        public HotelImageEntity HotelImage { get; set; }

        public HotelStreetEntity HotelStreet { get; set; }

        public ICollection<BookingEntity> Booking { get; set; }
    }
}
