using Api.Dto;
using Api.Interfaces;
using Api.Mappings;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    //Todo Test this controller when there is actually any data in the Anmeldelser table
    [Route("[controller]")]
    [ApiController]
    public class AnmeldelseController(IAnmeldelseRepository anmeldelseRepository) : ControllerBase
    {
        private readonly IAnmeldelseRepository _anmeldelseRepository = anmeldelseRepository;

        // userId er valgfrit. Værdien er den bruger der er logged ind
        [HttpGet("FilmAnmeldelser/{filmId}/{userId?}")]
        public IActionResult GetFilmAnmeldelser(int filmId, int? userId = null) // userId skal ha' en default value, for at håndterer hvis den ikke angives
        {
            var anmeldelser = Map.ToDto(_anmeldelseRepository.GetFilmAnmeldelser(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (anmeldelser.Count == 0)
                return NotFound("Der er ikke givet nogen anmeldelser endnu.");

            //todo Test if the ordering actually works
            // Tjekker efter om the
            if (userId != null && anmeldelser.Any(a => a.AnmelderId == userId))
                // "OrderBy" sortere her listen som en bool, hvor true står først
                return Ok(anmeldelser.OrderByDescending(a => a.AnmelderId == userId));
            else
                return Ok(anmeldelser);
        }


        [HttpGet("FilmAnmeldelser/{userId}")]
        public IActionResult GetUserAnmeldelser(int userId)
        {

            var anmeldelser = Map.ToDto(_anmeldelseRepository.GetUserAnmeldelser(userId)).OrderByDescending(a => a.Anmeldsdato);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (anmeldelser.Count() == 0)
                return NotFound("Du har ikke givet nogen film en anmeldelse");

            return Ok(anmeldelser);
        }
    }
}
