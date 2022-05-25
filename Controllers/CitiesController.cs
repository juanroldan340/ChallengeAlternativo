using ChallengeAlternativo.Data;
using ChallengeAlternativo.Models;
using ChallengeAlternativo.Repositories;
using ChallengeAlternativo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlternativo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        private readonly ICitiesRepository _repository;

        public CitiesController(ICitiesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _repository.Get();

            var listViewModel = new List<GetCityViewModel>();

            foreach (var city in cities)
            {
                listViewModel.Add(new GetCityViewModel() { 
                    Image = city.Image,
                    Name = city.Name,
                    Population = city.Population
                });
            }

            return Ok(listViewModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCity(int Id)
        {
            var model = await _repository.GetById(Id);

            if (model == null)
                return NotFound("No se ha encontrado la Ciudad o País especificado.");

            return Ok(model);
        }

        [HttpGet("continent")]
        public async Task<IActionResult> GetByContinent(int continentId)
        {
            var cities = await _repository.GetByContinent(continentId);

            if (cities == null)
                return NotFound("No se ha encontrado la Ciudad o País especificado.");

            return Ok(cities);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetCityByName(string name)
        {
            var city = await _repository.GetByName(name);

            if (city == null)
                return NotFound("No se encontró la Ciudad o País.");

            return Ok(city);
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrdered(string order)
        {
            if (order == string.Empty)
                return BadRequest("No te olvides de ingresar los caracteres.");

            order = order.ToUpper();

            return Ok(await _repository.GetOrdered(order));
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityViewModel city)
        {
            if (!await _repository.Add(city.ToCityModel()))
                return NotFound("Error al agregar al registro.");

            return Ok("Su ciudad o País ha sido agreagada correctamente.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int Id)
        {
            if (!await _repository.Delete(Id))
                return NotFound("No se encuentra el registro.");

            return Ok("Su Ciudad o País ha sido eliminado satisfactoriamente.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(AddCityViewModel city)
        {
            if (city == null)
                return BadRequest("Complete los campos correctamente");

            if (!await _repository.Update(city.ToCityModel()))
                return NotFound("No se ha encontrado la Ciudad o País.");

            return Ok("Su ciudad o país ha sido modificado correctamente.");
        }

    }
}
