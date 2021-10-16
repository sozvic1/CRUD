using System;

namespace AnimalsCore.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Breed Breed { get; set; }

    }
}
