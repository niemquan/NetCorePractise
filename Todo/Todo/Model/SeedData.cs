using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Model
{
    public class SeedData
    {
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using(var context = serviceProvider.GetRequiredService<AppDbContext>())
			{
				if(context.TodoItems.AnyAsync<TodoItem>().Result)
				{
					return;
				}

				context.TodoItems.Add(new TodoItem
				{
					Id = Guid.NewGuid(),
					Name = "Happy Test",
					IsComplete = true
				});
				context.SaveChanges();
			}


			using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
			{
				if (context.TodoItems.AnyAsync<TodoItem>().Result)
				{
					return;
				}

				context.TodoItems.AddRange(
					new TodoItem
					{
						Id = Guid.NewGuid(),
						Name = "Complete HeartBeat",
						IsComplete = false
					},
					new TodoItem
					{
						Id = Guid.NewGuid(),
						Name = "Practise asp.net core",
						IsComplete = false
					}
				);

				context.SaveChanges();

			}
		}
    }
}
