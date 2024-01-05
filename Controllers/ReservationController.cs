using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllReservation()
        {
            var reservations = _context.Reservations;
            if (reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetByIdReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost("create")]
        public IActionResult CreateReservation([FromBody] Reservation newReservation)
        {
            _context.Reservations.Add(newReservation);
            _context.SaveChanges();
            return Ok(newReservation);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return Ok(reservation);
        }
    }
}