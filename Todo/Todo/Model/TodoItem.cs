using System;

namespace Todo.Model
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public Person Person { get; set; }
    }
}               