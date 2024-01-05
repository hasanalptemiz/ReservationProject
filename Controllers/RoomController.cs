using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationProject.Models.ORM;
using ReservationProject.Context;

namespace ReservationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomController : ControllerBase
    {
        private readonly ReservationDbContext _context;

        public RoomController(ReservationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var rooms = _context.Rooms.ToList();
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Room newRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newRoom == null)
            {
                return BadRequest();
            }

            _context.Rooms.Add(newRoom);
            _context.SaveChanges();

            return Ok(newRoom);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Room newRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newRoom == null)
            {
                return BadRequest();
            }

            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            room.RoomName = newRoom.RoomName;

            _context.Rooms.Update(room);
            _context.SaveChanges();

            return Ok(room);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return Ok(room);
        }
    }
}