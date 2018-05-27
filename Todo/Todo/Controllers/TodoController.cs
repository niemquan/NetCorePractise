using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Controllers
{

    [Route("api/[controller]")]
    public class TodoController : Controller
    {
		private readonly AppDbContext _context;

		public TodoController(AppDbContext context)
		{
			_context = context;
			if(_context.TodoItems.Count() == 0)
			{
				TodoItem item = new TodoItem
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Finish self framework"
				};

				_context.Add<TodoItem>(item);
				_context.SaveChanges();
			}
		}
        
		[HttpGet()]
		public List<TodoItem> GetList()
		{
			return _context.TodoItems.ToList();
		}

		[HttpGet("/getTodoItem/{id}",Name = "api")]
		public IActionResult GetById(string id)
		{
			try
			{
				var item = _context.TodoItems.Find(id);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost]
		public IActionResult Create([FromBody]TodoItem todo)
		{
			if (todo == null)
				return BadRequest();
			_context.Add(todo);
			_context.SaveChanges();

			return CreatedAtRoute("api", new { id = todo.Id }, todo);
		}
    }
}
