using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    /// <summary>
    /// Har kortlagt Model objekterne og deres Dto.
    /// </summary>
    public static partial class Map
    {
        /// <summary>
        /// Creates a dto for a film.
        /// </summary>
        /// <param name="film"></param>
        /// <returns>The FilmDto.</returns>
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

        /// <summary>
        /// Creates a list of DTOs for film.
        /// </summary>
        /// <param name="film"></param>
        /// <returns>The list of DTOs</returns>
        public static List<FilmDto> ToDto(IEnumerable<Film> film)
        {
            List<FilmDto> dtoList = new();

            Parallel.ForEach(film, i =>
            {
                dtoList.Add(ToDto(i));
            });

            return dtoList;
        }
    }
}
