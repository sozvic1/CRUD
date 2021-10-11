using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static List<Animals> _animals = new List<Animals>()
        {
          new Animals() { Id = 1, Age = 5, Name = "Bob", Breed = "Buldog" },
          new Animals() { Id = 2, Age = 3, Name = "Cesar", Breed = "Taksa" },
          new Animals() { Id = 3, Age = 7, Name = "Neptun", Breed = "Rassel" },
          new Animals() { Id = 4, Age = 1, Name = "Charli", Breed = "RedRiver" }
         
        };

        private readonly ILogger<AnimalsController> _logger;

        public AnimalsController(ILogger<AnimalsController> logger)
        {
     
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_animals);
              
        }
        [HttpPost]
        public IActionResult Post(Animals animals)
        {
            animals.Id = 5;
            animals.Name = "Vasya";
            animals.Age = 10;
            animals.Breed = "Labrodor";
            _animals.Add(animals);


            return Created("5", animals);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Animals animals)
        {
            var value = _animals.Where(x => x.Id == id).FirstOrDefault();
            if (value != null)
            {
                foreach (var item in _animals)
                {
                    if (item.Id == id)
                    {
                        item.Breed = "Chappy";
                    }  
                }

                animals.Breed = "Chappy";
                return Ok(animals);
              
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var value = _animals.Where(x => x.Id == id).FirstOrDefault();
            if (value != null) 
                return Ok(value);
            else return NotFound();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _animals.Where(x => x.Id == id).FirstOrDefault();
            if (value != null)
            {
                _animals.Remove(value);
                return Ok(value);
            }
            return NotFound();

        }
    }
}
