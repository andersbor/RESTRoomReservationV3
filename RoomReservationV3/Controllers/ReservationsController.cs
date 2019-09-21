﻿using System;
using System.Collections.Generic;
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
            new Reservation {Id=1, RoomId = 1,FromTime = 1568981908, ToTime = 1568984908, Purpose = "Lesson"}
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
        [Route("room/{roomId}/{fromTime}/{toTime}")]
        public ActionResult<IEnumerable<Reservation>> GetByRoomIdAndTimeInterval(int roomId, int fromTime, int toTime)
        {
            if (fromTime > toTime)
                return BadRequest("FromTime > ToTime: " + fromTime + " > " + toTime);
            //DateTime early = new DateTime(year, month, day);
            //DateTime late = new DateTime(year, month, day, 23, 59, 59);
            //long earlyTicks = ConvertToUnixTime(early) / 1000;
            //long lateTicks = ConvertToUnixTime(late) / 1000;
            return Reservations.FindAll(reservation => reservation.RoomId == roomId &&
                                                       reservation.Intersects(fromTime, toTime));
        }

        // https://www.fluxbytes.com/csharp/convert-datetime-to-unix-time-in-c/
        private static readonly DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ConvertToUnixTime(DateTime datetime)
        {
            return (long)(datetime - sTime).TotalSeconds;
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IEnumerable<Reservation> GetByUserId(string userId)
        {
            return Reservations.FindAll(reservation => reservation.UserId == userId);
        }

        // POST: api/Reservations
        [HttpPost]
        public ActionResult<int> Post([FromBody] Reservation reservation)
        {
            // todo check roomId exists
            // todo check overlapping time intervals

            if (reservation.FromTime > reservation.ToTime)
            {
                return BadRequest("FromTime > ToTime: " + reservation.FromTime + " > " + reservation.ToTime);
            }

            Room room = new RoomsController().Get(reservation.RoomId);
            if (room == null)
            {
                return BadRequest("No such room: " + reservation.RoomId);
            }

            bool overlapping = Reservations.Exists(
                reservation1 => reservation1.RoomId == reservation.RoomId
                                && reservation1.Intersects(reservation));

            if (overlapping)
            {
                return BadRequest("Room occupied");
            }

            reservation.Id = _nextId++;
            Reservations.Add(reservation);
            return reservation.Id;
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
