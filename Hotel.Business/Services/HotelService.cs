﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Database.Entities;
using Database.Interfaces;

namespace Business.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelSystemRepository<HotelEntity> _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelSystemRepository<HotelEntity> hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<HotelModel>> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAll();

            return hotels
                .Select(h => _mapper.Map<HotelModel>(h))
                .AsQueryable();
        }

        public async Task AddHotel(HotelModel hotel)
        {
            await _hotelRepository.Create(_mapper.Map<HotelEntity>(hotel));
        }

        public async Task<HotelModel> GetHotel(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id is incorrect");
            }

            return _mapper.Map<HotelEntity, HotelModel>(await _hotelRepository.FindById(id));
        }

        public async Task DeleteHotel(Guid id)
        {
            HotelModel hotel = _mapper.Map<HotelModel>(await _hotelRepository.FindById(id));

            if (hotel == null)
            {
                throw new NullReferenceException("Hotel service is null");
            }

            await _hotelRepository.Delete(_mapper.Map<HotelEntity>(hotel));
        }

        public async Task UpdateHotel(Guid id, HotelModel updatedHotel)
        {
            HotelModel hotel = _mapper.Map<HotelModel>(await _hotelRepository.FindById(id));

            if (hotel == null)
            {
                throw new NullReferenceException("Hotel is null");
            }

            hotel = UpdateHotelOptions(hotel, updatedHotel);

            await _hotelRepository.Update(_mapper.Map<HotelEntity>(hotel));
        }

        private HotelModel UpdateHotelOptions(HotelModel hotel, HotelModel updatedHotel)
        {
            hotel.Id = updatedHotel.Id;
            hotel.Name = updatedHotel.Name;
            hotel.StarsNumber = updatedHotel.StarsNumber;
            hotel.Country = updatedHotel.Country;
            hotel.City = updatedHotel.City;
            hotel.Address = updatedHotel.Address;
            hotel.MinRoomPrice = updatedHotel.MinRoomPrice;
            hotel.IsFavorite = updatedHotel.IsFavorite;
            hotel.IsFreeRooms = updatedHotel.IsFreeRooms;
            return hotel;
        }
    }
}
