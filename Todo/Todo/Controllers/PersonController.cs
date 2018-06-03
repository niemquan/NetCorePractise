using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Model;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _context.Persons.Include(p => p.TodoItems);

            return new JsonResult(people.ToList());
        }

        [HttpGet("/{id}")]
        public IActionResult GetOnePerson(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var person = _context.Persons.Find(id);

            if (person != null)
            {
                return Ok(person);
            }

            return NotFound();
        }
    }
}
