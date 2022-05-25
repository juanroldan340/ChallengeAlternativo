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
    [Route("api/icons")]
    public class GeographicIconsController : ControllerBase
    {
        private readonly IGeographicIconsRepository _repository;

        public GeographicIconsController(IGeographicIconsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeographicIcons()
        {
            var list = await _repository.Get();
            
            var listViewModel = new List<GetGeographicIconsViewModel>();

            foreach (var gi in list)
            {
                listViewModel.Add(new GetGeographicIconsViewModel()
                {
                    Image = gi.Image,
                    Name = gi.Name,
                });
            }

            return Ok(listViewModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGeographicIcon(int Id)
        {
            var list = await _repository.GetById(Id);

            if (list == null)
                return NotFound("No se encontró el registro.");

            return Ok(list);
        }

        [HttpGet("name={name}")]
        public async Task<IActionResult> GetGeographicIconByName(string name)
        {
            var list = await _repository.GetByName(name);
            return Ok(list);
        }
        
        [HttpGet("name={name}")]
        public async Task<IActionResult> GetGeographicIconByCity(int cityId)
        {
            var list = await _repository.GetByCity(cityId);

            if (list == null)
                return NotFound("No se encontró registro.");

            return Ok(list);
        }

        [HttpGet("name={name}")]
        public async Task<IActionResult> GetGeographicIconByDate(DateTime date)
        {
            var list = await _repository.GetAllByDate(date);

            if (list == null)
                return NotFound("No se encontró registros por la fecha especificada.");

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddGeographicIcon(AddGeographicIconsViewModel geoIcon)
        {
            if (!await _repository.Add(geoIcon.ToGeographicIconModel()))
                return NotFound("Error al agregar Ícono");

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGeographicIcon(int Id)
        {
            var result = await _repository.Delete(Id);

            if(!result)
                return NotFound("No encontrado");

            return Ok("Su Ícono geográfico ha sido eliminado.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeographicIcon(GeographicIcon geoIcon)
        {
            var result = await _repository.Update(geoIcon);

            if (!result)
                return NotFound();

            return await GetGeographicIcons();
        }
    }
}
