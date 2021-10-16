using AnimalsCore.Models;
using System;
using System.Collections.Generic;

namespace AnimalsDataLayer
{
    public interface IAnimalsRepository
    {
        Guid Create(Animal animal);
        Animal DeleteById(Guid id);
        List<Animal> GetAll();
        Animal GetById(Guid id);
        Animal Update(Guid id, Animal animal);
    }
}