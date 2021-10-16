using AnimalsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsDataLayer
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private IAnimalsRepository _animalsRepository;
        private  List<Animal> _animals;
        public AnimalsRepository(IAnimalsRepository animalsRepository )
        {
            _animalsRepository = animalsRepository;
            _animals = new List<Animal>();
        }
        public Guid Create(Animal animal)
        {
            animal.Id = Guid.NewGuid();

            _animals.Add(animal);

            return animal.Id;
        }
        public List<Animal> GetAll()
        {
            return _animals;
        }
        public Animal GetById(Guid id)
        {
            var oldAnimals = _animals.FirstOrDefault(x => x.Id == id);
            if (oldAnimals != null)
            {
                return oldAnimals;
            }
            return null;
        }

        public Animal Update(Guid id, Animal animal)
        {
            var oldAnimals = _animals.FirstOrDefault(x => x.Id == animal.Id);
            if (oldAnimals != null)
            {
                var index = _animals.IndexOf(oldAnimals);
                _animals[index] = animal;

                return animal;
            }

            return null;
        }
        public Animal DeleteById(Guid id)
        {
            var oldAnimal = _animals.FirstOrDefault(x => x.Id == id);
            if (oldAnimal != null)
            {
                _animals.Remove(oldAnimal);
            }           

            return oldAnimal;
        }
    }
}
