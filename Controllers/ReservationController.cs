using Microsoft.AspNetCore.Mvc;
using CoreDominationBootCamp.Models.ORM;
using CoreDominationBootCamp.Context;

namespace CoreDominationBootCamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly CoreDominationDbContext _context;

        public ReservationController(CoreDominationDbContext context)
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

        [HttpPut("update/{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] Reservation newReservation)
        {
            var reservation = _context.Reservations.Find(id);
            reservation.ClientId = newReservation.ClientId;
            reservation.RoomId = newReservation.RoomId;
            reservation.StartDate = newReservation.StartDate;
            reservation.EndDate = newReservation.EndDate;
            reservation.AddDate = newReservation.AddDate;
            reservation.UpdateDate = newReservation.UpdateDate;
            reservation.DeleteDate = newReservation.DeleteDate;
            reservation.IsActive = newReservation.IsActive;
            _context.SaveChanges();
            return Ok(reservation);
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