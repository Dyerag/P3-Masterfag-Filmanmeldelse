using Api.Models;
using Microsoft.Identity.Client;

namespace Api.Interfaces
{
    public interface IFilmRepository
    {
        /// <summary>
        /// Skaber en tilfældig liste af film ud fra den angivne størrelse.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        ICollection<Film> GetRandomFilms(int amount);
        
        /// <summary>
        /// Henter en film ud fra dens ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Film GetFilm(int id);

        /// <summary>
        /// Henter alle film tilhørende den valgte genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        ICollection<Film> GetFilmsByGenre(string genre);

        /// <summary>
        /// Henter alle film, hvis titel inkludere hvad der søges efter. Er case insensitiv
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        ICollection<Film> GetFilmsByTitle(string title);
        
        /// <summary>
        /// Tjekker om filmen findes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool FilmExists(int id);
    }
}
