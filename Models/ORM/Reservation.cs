using System.ComponentModel.DataAnnotations;

namespace ReservationProject.Models.ORM
{
    public class Reservation : BaseModel
    {
        [Required(ErrorMessage = "Reservation Date is required")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Check In Date is required")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check Out Date is required")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Room Id is required")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required(ErrorMessage = "Client Id is required")]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}