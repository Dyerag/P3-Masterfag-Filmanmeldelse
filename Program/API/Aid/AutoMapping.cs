using AutoMapper;
using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Models;

namespace FilmAnmeldelseApi.Aid
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Film, FilmDto>();
        }
    }
}
