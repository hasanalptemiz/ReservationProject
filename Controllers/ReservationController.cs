using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationProject.Models.ORM;
using ReservationProject.Context;

namespace ReservationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationDbContext _context;

        public ReservationController(ReservationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var reservations = _context.Reservations.Include(x => x.Client).Include(x => x.Room).Include(x => x.Client.Company).ToList();
            if (reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var reservation = _context.Reservations.Include(x => x.Client).Include(x => x.Room).Include(x => x.Client.Company).FirstOrDefault(x => x.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Reservation newReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newReservation == null)
            {
                return BadRequest();
            }
            newReservation.AddDate = DateTime.Now;
            Room? room = _context.Rooms.Find(newReservation.RoomId);

            if (room == null)
            {
                return NotFound();
            }

            Client? client = _context.Clients.Find(newReservation.ClientId);

            if (client == null)
            {
                return NotFound();
            }

            newReservation.Room = room;
            newReservation.Client = client;
            newReservation.RoomId = room.Id;
            newReservation.Client = client;
            newReservation.ClientId = client.Id;
            _context.Reservations.Add(newReservation);
            return Ok(newReservation);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Reservation newReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newReservation == null || newReservation.Id != id)
            {
                return BadRequest();
            }
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }
            Client client = _context.Clients.Find(newReservation.ClientId);
            Room room = _context.Rooms.Find(newReservation.RoomId); 
            if (client == null || room == null){return NotFound();} 
            reservation.CheckInDate = newReservation.CheckInDate;
            reservation.CheckOutDate = newReservation.CheckOutDate;
            reservation.RoomId = newReservation.RoomId;
            reservation.ClientId = newReservation.ClientId;
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null){ return NotFound();}
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }
    }
}