using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationProject.Models.ORM;
using ReservationProject.Context;

namespace ReservationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase{
        private readonly ReservationDbContext _context;

        public ClientController(ReservationDbContext context){
            _context = context;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll(){
            var clients = _context.Clients.Include(x => x.Company).ToList();
            if (clients == null){
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id){
            var client = _context.Clients.Include(x => x.Company).FirstOrDefault(x => x.Id == id);

            if (client == null){
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Client newClient){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (newClient == null){
                return BadRequest();
            }
            Company company = _context.Companies.Find(newClient.CompanyId);
            if (company == null){
                return NotFound();
            }
            newClient.AddDate = DateTime.Now;
            newClient.Company = company;
            _context.Clients.Add(newClient);
            _context.SaveChanges();

            return Ok(newClient);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Client newClient){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (newClient == null){
                return BadRequest();
            }
            Client? client = _context.Clients.Find(id);
            if (client == null){
                return NotFound();
            }
            Company company = _context.Companies.Find(newClient.CompanyId);
            if (company == null){
                return NotFound();
            }
            client.Name = newClient.Name;
            client.Surname = newClient.Surname;
            client.BirthDate = newClient.BirthDate;
            client.Address = newClient.Address;
            client.email = newClient.email;
            client.Company = company;
            client.CompanyId = newClient.CompanyId;
            _context.Clients.Update(client);
            _context.SaveChanges();

            return Ok(client);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id){
            var client = _context.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null){
                return NotFound();
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return Ok(client);

    }
}
}
