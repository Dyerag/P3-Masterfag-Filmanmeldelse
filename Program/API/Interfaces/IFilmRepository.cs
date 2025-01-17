using Api.Models;
using Microsoft.Identity.Client;

namespace Api.Interfaces
{
    public interface IFilmRepository
    {
        /// <summary>
        /// Grabs random Films from the database.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>A list containing the chosen amount of films.</returns>
        ICollection<Film> GetRandomFilms(int amount);
        
        /// <summary>
        /// Fetches a single film by its ID from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The fetched film, otherwise null.</returns>
        Film GetFilm(int id);

        /// <summary>
        /// Finds all the movies belonging to a specific genre in the database.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Every film Found.</returns>
        ICollection<Film> GetFilmsByGenre(string genre);

        /// <summary>
        /// Searches the database for every film whoms title contains the parameter value.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>A list of found films.</returns>
        ICollection<Film> GetFilmsByTitle(string title);
        
        /// <summary>
        /// Checks if the film exists in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if it exists, otherwise False.</returns>
        bool FilmExists(int id);
    }
}
