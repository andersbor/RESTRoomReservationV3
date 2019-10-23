using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoomReservationV3.model;

namespace RoomReservationV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public static readonly List<Room> Rooms = new List<Room>
        {
            new Room {Id =1, Name="RO-D3.07", Capacity = 35, Description = "Class Room"},
            new Room {Id=2, Name="RO-D3.11", Capacity = 35, Description = "Class Room"},
            new Room {Id=3, Name="A2.015", Capacity = 6, Description = "Study Room"},
            new Room  {Id=4, Name="RO-D3.16", Capacity = 25, Description = "Class Room"},
            new Room {Id=5, Name = "D3.09", Capacity = 25, Description = "Class Room"}
        };

        [HttpGet]
        [Route("free/{time}")]
        public IEnumerable<Room> GetAvailableRooms(int time)
        {
            // https://stackoverflow.com/questions/6253656/how-do-i-join-two-lists-using-linq-or-lambda-expressions
            List<Reservation> reserved = ReservationsController.Reservations.FindAll(res => res.FromTime <= time && time <= res.ToTime);

            List<Room> copyOfRooms = new List<Room>(Rooms);
            reserved.ForEach(res => copyOfRooms.RemoveAll(room => res.RoomId == room.Id));
            return copyOfRooms;
            //return Rooms.Join(ReservationsController.Reservations,
            //  room => room.Id, res => res.RoomId, (room, res) => res.FromTime <= time && time <= res.ToTime
            //  );
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return Rooms;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public Room Get(int id)
        {
            return Rooms.FirstOrDefault(room => room.Id == id);
        }

        [HttpGet("name/{roomName}", Name = "Get")]
        public Room Get(string roomName)
        {
            return Rooms.FirstOrDefault(room => room.Name == roomName);
        }

        // POST: api/Rooms
        /*[HttpPost]
        public void Post([FromBody] Room value)
        {
        }*/

        // PUT: api/Rooms/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] Room value)
        {

        }*/

        // DELETE: api/ApiWithActions/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rooms.RemoveAll(room => room.Id == id);
        }*/
    }
}
