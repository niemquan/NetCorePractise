using System;
using Microsoft.EntityFrameworkCore;

namespace Todo.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<TodoItem> TodoItems { get; set; }
    }
}
