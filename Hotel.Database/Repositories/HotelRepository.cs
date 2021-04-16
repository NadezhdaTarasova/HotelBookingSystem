﻿using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Hotel.Database.Entities
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext Context;
        public HotelRepository(HotelContext context)
        {
            Context = context;
        }
        public IQueryable<HotelEntity> GetQueryable()
        {
            return Context.Hotels;
        }
        public HotelEntity GetHotelById(int id)
        {
            try
            {
                return Context.Hotels.Where(x => x.Id == id).FirstOrDefault();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void AddHotel(HotelEntity hotel)
        {
            try
            {
                Context.Hotels.Add(hotel);
                Context.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        public void UpdateHotel(HotelEntity hotel)
        {
            try
            {
                Context.Entry(hotel).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteHotel(int id)
        {
            try 
            {
                Context.Hotels.Remove(Context.Hotels.Where(x => x.Id == id).FirstOrDefault());
                Context.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
