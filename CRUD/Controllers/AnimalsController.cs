using AnimalsBusinesLayer;
using AnimalsBusinesLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsService _animalsService;
        public AnimalsController(IAnimalsService animalsService)
        {
            _animalsService =  animalsService;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var items = await _animalsService.GetAllAnimals();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = _animalsService.GetAnimalById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalById(Guid id)
        {
            var item = _animalsService.DeleteAnimalById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateAnimal(AnimalDTO animal)
        {
            var guid = await _animalsService.CreateAnimal(animal);
            if (guid != Guid.Empty)
            {
                return Ok(guid);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(Guid id, AnimalDTO animal)
        {
            
            var updateAnimal = await _animalsService.UpdateAnimal(id,animal);
            if (updateAnimal != null)
            {
                return Ok(updateAnimal);
            }
            return BadRequest();
        }
    }
}
