using System;

namespace HelloMutation.Domain.Entities
{
    public record Publisher
    {
        public Publisher(string name) => Name = name;

        private string _name;
        public string Name
        {
            get => _name;
            init => _name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(nameof(Name));
        }
    }
}