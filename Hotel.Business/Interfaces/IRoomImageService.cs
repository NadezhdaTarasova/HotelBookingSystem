﻿using Business.Models;
using System;

namespace Business.Interfaces
{
    public interface IRoomImageService
    {
        RoomImageModel GetRoomImageById (Guid roomImageId);

        bool AddRoomImage (RoomImageModel roomImage);

        bool UpdateRoomImage (RoomImageModel roomImage);

        bool DeleteRoomImage (Guid roomImageId);
    }
}
