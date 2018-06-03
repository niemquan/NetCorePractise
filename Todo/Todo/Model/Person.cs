using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Model
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
