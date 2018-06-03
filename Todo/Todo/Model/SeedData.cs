using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Model
{
    public class SeedData
    {
		public static void Initialize(IServiceProvider serviceProvider)
		{

            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {

                context.Database.EnsureCreated();
                context.Database.Migrate();

                Guid PersonId = Guid.NewGuid();

                Person person = new Person
                {
                    Age = 28,
                    Id = PersonId,
                    Name = "JasonNie"
                };

                if (context.Persons.AnyAsync<Person>().Result)
                {
                    return;
                }
                else
                {
                    context.Persons.Add(person);
                    context.SaveChanges();
                }

                if (context.TodoItems.AnyAsync<TodoItem>().Result)
                {
                    return;
                }
                else
                {
                    context.TodoItems.Add(new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Happy Test",
                        IsComplete = true,
                        Person = person
                    });
                    context.TodoItems.Add(new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "JasonNie Test",
                        IsComplete = false,
                        Person = person
                    });
                    context.SaveChanges();
                }

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
