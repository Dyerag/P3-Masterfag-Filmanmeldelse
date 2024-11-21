using FilmAnmeldelseApi.Models;
using Microsoft.Identity.Client;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IFilmRepository
    {
        ICollection<Film> GetRandomFilms(int amount);
        Film GetFilm(int id);
        ICollection<Film> GetFilmsByGenre(string genre);
        ICollection<Film> GetFilmsByTitle(string title);
        bool FilmExists(int id);
    }
}
