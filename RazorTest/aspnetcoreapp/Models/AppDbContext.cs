using System;
using Microsoft.EntityFrameworkCore;

namespace aspnetcoreapp.Models
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions options)
			:base(options)
        {
        }

		public DbSet<Customer> Customers { get; set; }
    }
}
