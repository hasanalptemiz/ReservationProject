using System.ComponentModel.DataAnnotations;

namespace ReservationProject.Models.ORM
{
    public class Room : BaseModel
    {
        [Required(ErrorMessage = "Room Name is required")]
        public string RoomName { get; set; }
    }
}