﻿using AutoMapper;
using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAnmeldelseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
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

        //Test if GetFilmByTitle works when no title is found
        [HttpGet("FindTitle/{title}")]
        public IActionResult GetFilmByTitle(string title)
        {
            var films = _mapper.Map<List<FilmDto>>(_filmRepository.GetFilmsByTitle(title));

            if (films.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //make it then sort by amount of ratings. Currently not setup
            films.OrderByDescending(f => f.Gennemsnitsanmeldelse);

            return Ok(films);
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