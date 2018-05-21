using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetcoreapp.Models
{
    public class Customer
    {
		public Guid Id { get; set; }

        [Required,StringLength(100)]
		public string Name { get; set; }
    }
}
