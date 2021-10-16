using AnimalsBusinesLayer.DTOs;
using AnimalsCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsBusinesLayer
{
    public interface IAnimalsService
    {
        Task<Guid> CreateAnimal(AnimalDTO animalDTO);
        Task<Animal> DeleteAnimalById(Guid id);
        Task<IEnumerable<Animal>> GetAllAnimals();
        Task<Animal> GetAnimalById(Guid id);
        Task<Animal> UpdateAnimal(Guid id, AnimalDTO animalDTO);
    }
}