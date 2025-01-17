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
        // userId is the ID of the user currently loggedin. It's optional, because it's possible to use the program without being loggedin.
        // FilmId is the whoms reviews are being fetched.
        // todo Test if the optional parameter works in the actual program, as swagger does not support optional parameters
        [HttpGet("Film/{filmId}/User/{userId?}")]
        public IActionResult GetFilmAnmeldelser(int filmId, int? userId = null) // userId needs a default value, to handle when one isn't given.
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound("Kan ikke give Anmeldelser til en film der ikke findes");

            var anmeldelser = Map.ToDto(_anmeldelseRepository.GetFilmAnmeldelser(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (anmeldelser.Count == 0)
                return NotFound("Ingen anmeldelser");

            //todo Test if the ordering actually works
            // Checks if a userid is given, and if the reviewerId of one of reviews is the same as the userId.
            if (userId != null && anmeldelser.Any(a => a.AnmelderId == userId))
                // "OrderBy" Sorts the list as a bool, with the results that return as true place first.
                return Ok(anmeldelser.OrderByDescending(a => a.AnmelderId == userId));
            else
                return Ok(anmeldelser);
        }

        //Todo Notfound check works. Add data to the database to test if the endpoint can return a 200 response
        [HttpGet("User/{userId}")]
        public IActionResult GetUserAnmeldelser(int userId)
        {
            var reviews = Map.ToDto(_anmeldelseRepository.GetUserAnmeldelser(userId).OrderByDescending(a => a.Anmeldsdato));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (reviews.Count == 0)
                return NotFound("Du har ikke givet nogen film en anmeldelse.");
            
            return Ok(reviews);
        }
    }
}
