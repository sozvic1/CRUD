using AnimalsBusinesLayer.DTOs;
using AnimalsCore.Models;
using AnimalsDataLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsBusinesLayer
{
    public class AnimalsService : IAnimalsService
    {       
        private  IAnimalsRepository _animalRepository;
        public AnimalsService(IAnimalsRepository animalsRepository)
        {
            _animalRepository = animalsRepository;
        }

        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            await Task.CompletedTask;
            return _animalRepository.GetAll();
        }

        public async Task<Animal> GetAnimalById(Guid id)
        {
            await Task.CompletedTask;
            return _animalRepository.GetById(id);
        }

        public async Task<Animal> DeleteAnimalById(Guid id)
        {
            await Task.CompletedTask;
            return _animalRepository.DeleteById(id);
        }

        public async Task<Guid> CreateAnimal(AnimalDTO animalDTO)
        {
            await Task.CompletedTask;
            if (Enum.TryParse(typeof(Breed), animalDTO.Breed, out var breed))
            {
                var animal = new Animal
                {
                    Breed = (Breed)breed,
                    Name = animalDTO.Name,
                    Age = animalDTO.Age
                };
                return _animalRepository.Create(animal);
            }

            return Guid.Empty;
        }

        public async Task<Animal> UpdateAnimal(Guid id, AnimalDTO animalDTO)
        {
            await Task.CompletedTask;
            if (Enum.TryParse(typeof(Breed), animalDTO.Breed, out var breed))
            {
                var animal = new Animal
                {
                    Id = id,
                    Breed = (Breed)breed,
                    Name = animalDTO.Name,
                    Age = animalDTO.Age
                };
                return _animalRepository.Update(id, animal);

            }
            return null;

        }
    }
}
