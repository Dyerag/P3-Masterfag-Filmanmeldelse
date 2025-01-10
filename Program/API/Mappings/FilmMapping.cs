using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    /// <summary>
    /// Returnerer en Dto der er kortlagt efter parameteren
    /// </summary>
    public static partial class Map
    {
        public static FilmDto ToDto(Film film) => new FilmDto
        {
            Id = film.Id,
            Titel = film.Titel,
            Plakat = film.Plakat,
            Synopse = film.Synopse,
            Aldersgrænse = film.Aldersgrænse,
            Udgivelsesdato = film.Udgivelsesdato,
            Spilletid = film.Spilletid,
            Gennemsnitsanmeldelse = film.Gennemsnitsanmeldelse
        };

        public static List<FilmDto> ToDto(IEnumerable<Film> film) => (List<FilmDto>)film.Select(ToDto);
    }
}
