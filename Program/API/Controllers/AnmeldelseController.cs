using Api.Interfaces;
using Api.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //Todo Test this controller when there is actually any data in the Anmeldelser table
    [Route("Api/[controller]")]
    [ApiController]
    public class AnmeldelseController(IAnmeldelseRepository anmeldelseRepository, IFilmRepository filmRepository) : ControllerBase
    {
        private readonly IAnmeldelseRepository _anmeldelseRepository = anmeldelseRepository;
        private readonly IFilmRepository _filmRepository = filmRepository;
        // userId er ID'en på den bruger som er logged in, og er valgfri, fordi det er muligt at bruge programmet uden at logge in.
        // FilmId er Den film hvis anmeldelser der hentes
        // todo Test if the optional parameter works in the actual program, as swagger does not support optional parameters
        [HttpGet("Film/{filmId}/User/{userId?}")]
        public IActionResult GetFilmAnmeldelser(int filmId, int? userId = null) // userId skal ha' en default value, for at håndterer hvis den ikke angives
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound("Kan ikke give Anmeldelser til en film der ikke findes");

            var anmeldelser = Map.ToDto(_anmeldelseRepository.GetFilmAnmeldelser(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (anmeldelser.Count == 0)
                return NotFound("Ingen anmeldelser");

            //todo Test if the ordering actually works
            // Tjekker om der er angivet et bruger id, og om nogen af objekterne i listen indeholder id'en
            if (userId != null && anmeldelser.Any(a => a.AnmelderId == userId))
                // "OrderBy" sortere her listen som en bool, hvor true står først
                return Ok(anmeldelser.OrderByDescending(a => a.AnmelderId == userId));
            else
                return Ok(anmeldelser);
        }

        //Todo Notfound check works. Add data to the database to test if the endpoint can return a 200 response
        [HttpGet("User/{userId}")]
        public IActionResult GetUserAnmeldelser(int userId)
        {
            var anmeldelser = Map.ToDto(_anmeldelseRepository.GetUserAnmeldelser(userId).OrderByDescending(a => a.Anmeldsdato));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (anmeldelser.Count == 0)
                return NotFound("Du har ikke givet nogen film en anmeldelse.");

            return Ok(anmeldelser);
        }
    }
}
