using System.ComponentModel.DataAnnotations;

namespace ReservationProject.Models.ORM
{
    public class Company : BaseModel
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        public string Address { get; set; } 

        
    }
}

