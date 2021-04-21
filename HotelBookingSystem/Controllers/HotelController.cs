﻿using AutoMapper;
using Business.DTO;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        
        public HotelController(IHotelService hotelService, ILogger<HotelController> logger, IMapper mapper)
        {
            _hotelService = hotelService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("GetExceptioInfo")]
        [HttpGet]
        public IEnumerable<string> GetExeptionInfo() //экшн-метод, чтобы пробросить исключение
        {
            string[] arrRetValues = null;
            if (arrRetValues.Length > 0)
            {

            }
            return arrRetValues;
        }

        [HttpGet("{id}", Name = "GetHotelEntity")]
        public IActionResult Get(Guid hotelId)
        {
            return Ok(_mapper.Map<Hotel>(_hotelService.GetHotelById(hotelId)));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Hotel hotel)
        {
            _hotelService.AddHotel(_mapper.Map<HotelModel>(hotel));
            return Ok(_mapper.Map<Hotel>(hotel));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] HotelForUpdate hotelForUpdate)
        {
            var hotelUpdate = _hotelService.UpdateHotel(_mapper.Map<HotelModel>(hotelForUpdate));
            return Ok(_mapper.Map<Hotel>(hotelUpdate));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid hotelId)
        {
            var deletedHotel = _hotelService.GetHotelById(hotelId);

            if (deletedHotel == null)
            {
                return NotFound("Hotel is not found");
            }
            _hotelService.DeleteHotel(hotelId);
            return Ok("Hotel deleted");
        }
    }
}
