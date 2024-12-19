﻿using AutoMapper;
using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmAnmeldelseApi.Controllers
{
    //Todo Test this controller when there is actually any data in the Anmeldelser table
    [Route("[controller]")]
    [ApiController]
    public class AnmeldelseController(IAnmeldelseRepository anmeldelseRepository, IMapper mapper) : ControllerBase
    {
        private readonly IAnmeldelseRepository _anmeldelseRepository = anmeldelseRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet("FilmAnmeldelser/{filmId}/{userId}")]
        public IActionResult GetFilmAnmeldelser(int filmId, int userId = 0)
        {
            var anmeldelser = _mapper.Map<List<AnmeldelseDto>>(_anmeldelseRepository.GetFilmAnmeldelser(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (userId != 0)
            {
                List<AnmeldelseDto> userFirstAnmeldelser = [];

                foreach (var anmeldelse in anmeldelser)
                {
                    if (anmeldelse.AnmelderId == userId)
                    {
                        userFirstAnmeldelser.Add(anmeldelse);
                        anmeldelser.Remove(anmeldelse);

                        userFirstAnmeldelser.AddRange(anmeldelser);
                        
                        return Ok(userFirstAnmeldelser);
                    }
                }
            }

            return Ok(anmeldelser);
        }
    }
}