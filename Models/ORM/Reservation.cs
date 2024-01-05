using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationProject.Models.ORM
{
    public class Reservation : BaseModel
    {
        
        [Required(ErrorMessage = "Check In Date is required")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check Out Date is required")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Room Id is required")]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required(ErrorMessage = "Client Id is required")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}