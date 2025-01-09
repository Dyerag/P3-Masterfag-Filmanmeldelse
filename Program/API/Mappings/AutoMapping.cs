using AutoMapper;
using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    /// <summary>
    /// kortlægger Modellerne til deres tilsvarende DTO. DTO'en er den data der returneres af API'en
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Film, FilmDto>();
            CreateMap<Anmeldelse, AnmeldelseDto>();

        }

    }

}
