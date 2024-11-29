using AutoMapper;
using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmAnmeldelseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        //IFilmRepository er scoped til FilmRepository
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmController(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        [HttpGet("FindID/{filmId}")]
        public IActionResult GetFilm(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound();

            var film = _mapper.Map<FilmDto>(_filmRepository.GetFilm(filmId));

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

            //todo make GetFilmByTitle sort the returned list- in descending order- by average rating followed by total ratings
            return Ok(films.OrderByDescending(f => f.Gennemsnitsanmeldelse));
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
