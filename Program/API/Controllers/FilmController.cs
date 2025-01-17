using Api.Mappings;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class FilmController(IFilmRepository filmRepository, IAnmeldelseRepository anmeldelserRepository) : ControllerBase
    {
        //IFilmRepository is scopde to FilmRepository.
        private readonly IFilmRepository _filmRepository = filmRepository;
        // IAnmeldelserRepository is used to sort the order of films searched by title.
        private readonly IAnmeldelseRepository _anmeldelseRepository = anmeldelserRepository;

        [HttpGet("FindID/{filmId}")]
        public IActionResult GetFilm(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound("Filmen findes ikke");

            var film = Map.ToDto(_filmRepository.GetFilm(filmId));
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(film);
        }

        [HttpGet("RandomFilms/{amount}")]
        public IActionResult GetRandomFilms(int amount)
        {
            var films = Map.ToDto(_filmRepository.GetRandomFilms(amount));
            
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(films);
        }

        [HttpGet("FindTitle/{title}")]
        public IActionResult GetFilmsByTitle(string title)
        {
            var films = Map.ToDto(_filmRepository.GetFilmsByTitle(title));

            if (films.Count == 0)
                return NotFound("Der er ingen film der passer titlen");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //todo Test that GetFilmsByTitle returns a list ordered by, in descending order, GennemsnitsAnmeldelse, and then the amount of reviews.
            // The returned list is sorted by highest average rating first, and then amount of reviews.
            return Ok(films.OrderByDescending(f => f.Gennemsnitsanmeldelse).ThenByDescending(f => _anmeldelseRepository.GetFilmAnmeldelser(f.Id).Count));
        }

        [HttpGet("Genre/{genre}")]
        public IActionResult GetFilmsByGenre(string genre)
        {
            var films = Map.ToDto(_filmRepository.GetFilmsByGenre(genre));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(films);
        }

        //Todo Make a Method to calculate the average rating of all a movies reviews
    }
}
