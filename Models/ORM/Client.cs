using System.ComponentModel.DataAnnotations;

namespace  ReservationProject.Models.ORM
{
    public class Client : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? email { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}