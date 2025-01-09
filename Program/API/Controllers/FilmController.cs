using AutoMapper;
using Api.Mappings;
using Api.Dto;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmController(IFilmRepository filmRepository, IMapper mapper, IAnmeldelseRepository anmeldelserRepository) : ControllerBase
    {
        //IFilmRepository er scoped til FilmRepository
        private readonly IFilmRepository _filmRepository = filmRepository;
        private readonly IMapper _mapper = mapper;
        // IAnmeldelserRepository bruges til at sortere rækkefølgen af film der er søgt gennem titlen
        private readonly IAnmeldelseRepository _anmeldelseRepository = anmeldelserRepository;

        [HttpGet("FindID/{filmId}")]
        public IActionResult GetFilm(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound();

            //var film = _mapper.Map<FilmDto>(_filmRepository.GetFilm(filmId));
            var film = Map.ToDto(_filmRepository.GetFilm(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(film);
        }

        [HttpGet("RandomFilms/{amount}")]
        public IActionResult GetRandomFilms(int amount)
        {
            var films = _mapper.Map<List<FilmDto>>(_filmRepository.GetRandomFilms(amount));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(films);
        }

        [HttpGet("FindTitle/{title}")]
        public IActionResult GetFilmsByTitle(string title)
        {
            var films = _mapper.Map<List<FilmDto>>(_filmRepository.GetFilmsByTitle(title));

            if (films.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //todo Test that GetFilmsByTitle returns a list ordered by, in descending order, GennemsnitsAnmeldelse, and then the amount of reviews.
            // Den returnerede liste er sorteret efter den film med højst gennemsnit først, og derefter antallet af anmeldelser
            return Ok(films.OrderByDescending(f => f.Gennemsnitsanmeldelse).ThenByDescending(f => _anmeldelseRepository.GetFilmAnmeldelser(f.Id).Count));
        }

        [HttpGet("{genre}")]
        public IActionResult GetFilmsByGenre(string genre)
        {
            var films = _mapper.Map<List<FilmDto>>(_filmRepository.GetFilmsByGenre(genre));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(films);
        }
    }
}
