using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  ReservationProject.Models.ORM
{
    public class Client : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? email { get; set; }

        [Required(ErrorMessage = "Company Id is required")]
        [ForeignKey("Company")]

        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}