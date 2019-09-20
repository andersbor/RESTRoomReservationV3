using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomReservationV3.model;

namespace RoomReservationV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private static readonly List<Room> Rooms = new List<Room>
        {
            new Room {Id =1, Name="RO-D3.07", Capacity = 35, Description = "Class Room"},
            new Room {Id=2, Name="RO-D3.11", Capacity = 35, Description = "Class Room"},

        };

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

        [HttpGet("name/{name}", Name = "Get")]
        public Room Get(string name)
        {
            return Rooms.FirstOrDefault(room => room.Name == name);
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
