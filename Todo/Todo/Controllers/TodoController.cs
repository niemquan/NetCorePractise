using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		}

		[HttpGet()]
		public List<TodoItem> GetList()
		{
			return _context.TodoItems.ToList();
		}

		[HttpGet("/getTodoItem/{id}", Name = "api")]
		public IActionResult GetById(Guid id)
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
  


		[HttpPut("/UpdateItem/{id}")]
		public IActionResult Update(Guid id, [FromBody]TodoItem item)
		{
			if(item == null || id == Guid.Empty)
			{
				return BadRequest();
			}

			var todo = _context.TodoItems.Find(id);

			if(todo == null)
			{
				return NotFound();
			}

			todo.Name = item.Name;
			todo.IsComplete = item.IsComplete;
			_context.TodoItems.Update(todo);
			_context.SaveChanges();
			return CreatedAtRoute("api", new { id = todo.Id }, todo);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			if(id == Guid.Empty)
			{
				return BadRequest();
			}

			var item = _context.TodoItems.Find(id);
			_context.TodoItems.Remove(item);

			_context.SaveChanges();

			return CreatedAtRoute("api", new { id = item.Id }, item);
		}
    }
}
