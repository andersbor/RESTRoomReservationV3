﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoomReservationV3.model;

namespace RoomReservationV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static readonly List<Reservation> Reservations = new List<Reservation>
        {

        };

        private static int _nextId = 10;


        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return Reservations;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return Reservations.FirstOrDefault(reservation => reservation.Id == id);
        }

        [HttpGet]
        [Route("room/{roomId}")]
        public IEnumerable<Reservation> GetByRoomId(int roomId)
        {
            return Reservations.FindAll(reservation => reservation.RoomId == roomId);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IEnumerable<Reservation> GetByUserId(string userId)
        {
            return Reservations.FindAll(reservation => reservation.UserId == userId);
        }

        // TODO GET method with dates. Idea: roomid + Unix time, find all reservation in this day

        // POST: api/Reservations
        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            // todo check roomId exists
            // todo check overlapping time intervals
            reservation.Id = _nextId++;
            Reservations.Add(reservation);
        }

        // PUT: api/Reservations/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // todo check UserId, how??
            Reservations.RemoveAll(reservation => reservation.Id == id);
        }
    }
}