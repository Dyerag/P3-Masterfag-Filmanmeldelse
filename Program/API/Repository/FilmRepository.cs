using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAnmeldelseApi.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly DataContext _context;

        public FilmRepository(DataContext context) => _context = context;

        /// <summary>
        /// Tjekker om filmen findes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FilmExists(int id)
        {
            return _context.Films.Any(f => f.Id == id);
        }

        /// <summary>
        /// Henter filmen ud fra filmens ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Film? GetFilm(int id)
        {
            return _context.Films.Where(f => f.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Generere en tilfældig liste af film ud fra den angivne størrelse.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public ICollection<Film> GetRandomFilms(int amount)
        {
            return _context.Films.OrderBy(r => Guid.NewGuid()).Take(amount).ToList();
        }

        /// <summary>
        /// Henter Alle Film Tilhørende den valgte genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public ICollection<Film?> GetFilmsByGenre(string genre)
        {
            return _context.FilmGenres.Where(g => g.Genre1 == genre).Select(f => f.Film).ToList();
        }

        /// <summary>
        /// Henter alle film, hvis titel inkludere hvad der søges efter et sted i titlen. Er case insensitiv
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public ICollection<Film> GetFilmsByTitle(string title)
        {
            return _context.Films.Where(f => EF.Functions.Like(f.Titel, "%"+title+"%")).ToList();
        }
    }
}
