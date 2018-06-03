using System;
using Microsoft.EntityFrameworkCore;

namespace Todo.Model
{
	public sealed class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
           
		    
		}

		public DbSet<TodoItem> TodoItems { get; set; }

	    public DbSet<Person> Persons { get; set; }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
	        modelBuilder.Entity<TodoItem>().ToTable("TodoItems");

	        modelBuilder.Entity<Person>().ToTable("People");

	    }
	}
}
