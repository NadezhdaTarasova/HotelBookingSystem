﻿using Business.Interfaces;
using Business.Models;
using Database.Interfaces;
using Hotel.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class RoomImageService
    {
        private IRoomImageRepository _roomImageRepository;

        public RoomImageService(IRoomImageRepository roomImageRepository)
        {
            _roomImageRepository = roomImageRepository;
        }

        public bool AddRoomImage(RoomImageModel roomImage)
        {
            if (roomImage == null)
            {
                throw new NullReferenceException("Room image is incorrect");
            }
            return _roomImageRepository.Add(Mapper.Map<RoomImageModel, RoomImageEntity>(roomImage));
        }

        public bool DeleteRoomImage(Guid roomImageId)
        {
            if (roomImageId == null)
            {
                throw new NullReferenceException("Id is incorrect");
            }
            return _roomImageRepository.Delete(roomImageId);
        }

        public RoomImageModel GetRoomImageById(Guid roomImageId)
        {
            if (roomImageId == null)
            {
                throw new NullReferenceException("Id is incorrect");
            }
            return Mapper.Map<RoomImageEntity, RoomImageModel>(_roomImageRepository.GetById(roomImageId));
        }

        public bool UpateRoomImage(RoomImageModel roomImage)
        {
            if (roomImage == null)
            {
                throw new NullReferenceException("Room image is incorrect");
            }
            return _roomImageRepository.Update(Mapper.Map<RoomImageModel, RoomImageEntity>(roomImage));
        }
    }
}
