using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationProject.Models.ORM;
using ReservationProject.Context;

namespace ReservationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ReservationDbContext _context;

        public CompanyController(ReservationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var companies = _context.Companies.ToList();
            if (companies == null)
            {
                return NotFound();
            }
            return Ok(companies);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Company newCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newCompany == null)
            {
                return BadRequest();
            }
            newCompany.AddDate = DateTime.Now;
            _context.Companies.Add(newCompany);
            _context.SaveChanges();

            return Ok(newCompany);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Company newCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (newCompany == null)
            {
                return BadRequest();
            }
            var oldCompany = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (oldCompany == null)
            {
                return NotFound();
            }

            oldCompany.CompanyName = newCompany.CompanyName;
            oldCompany.Address = newCompany.Address;
            _context.Companies.Update(oldCompany);
            _context.SaveChanges();

            return Ok(oldCompany);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return Ok(company);
        }
    }
}
