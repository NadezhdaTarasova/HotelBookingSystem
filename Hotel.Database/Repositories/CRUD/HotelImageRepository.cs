﻿using Database.Entities;
using Database.Interfaces.CRUD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Database.Repositories.CRUD
{
    public class HotelImageRepository : IHotelImageRepository
    {
        private readonly HotelContext _context;

        public HotelImageRepository(HotelContext context)
        {
            _context = context;
        }

        public bool Add(HotelImageEntity hotelImage)
        {
            try
            {
                _context.HotelImages.Add(hotelImage);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw; 
            }
        }

        public bool Delete(Guid hotelImageId)
        {
            try
            {
                _context.HotelImages.Remove(_context.HotelImages.Where(x => x.Id == hotelImageId).FirstOrDefault());
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public HotelImageEntity GetById(Guid hotelImageId)
        {
            try
            {
                return _context.HotelImages.Where(x => x.Id == hotelImageId).FirstOrDefault();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<HotelImageEntity> GetQueryable()
        {
            return _context.HotelImages;
        }

        public bool Update(HotelImageEntity hotelImage)
        {
            try
            {
                _context.Entry(hotelImage).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}