﻿using AutoMapper;
using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Models;

namespace FilmAnmeldelseApi.Aid
{
    /// <summary>
    /// kortlægger Modellerne til deres tilsvarende DTO. DTO'en er den data der returneres af API'en
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Film, FilmDto>();
        }
    }
}
