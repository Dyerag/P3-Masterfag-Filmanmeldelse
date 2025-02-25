﻿using Api.Dto;
using Api.Models;

namespace Api.Mappings
{
    /// <summary>
    /// Har kortlagt Model objekterne og deres Dto.
    /// </summary>
    public static partial class Map
    {
        /// <summary>
        /// Skaber en FilmDto
        /// </summary>
        /// <param name="film"></param>
        /// <returns>Den skabte FilmDto</returns>
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
        /// Skaber en liste af FilmDto'er
        /// </summary>
        /// <param name="film"></param>
        /// <returns>Listen af FilmDto'er</returns>
        public static List<FilmDto> ToDto(IEnumerable<Film> film)
        {
            List<FilmDto> dtoListe = new();

            foreach (var i in film)
                dtoListe.Add(ToDto(i));

            return dtoListe;
        }
    }
}
