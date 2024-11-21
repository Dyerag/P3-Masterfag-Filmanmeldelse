using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAnmeldelseApi.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly DataContext _context;

        public FilmRepository(DataContext context)
        {
            _context = context;
        }

        public bool FilmExists(int id)
        {
            return _context.Films.Any(f => f.Id == id);
        }

        public Film GetFilm(int id)
        {
            return _context.Films.Where(f => f.Id == id).FirstOrDefault();
        }

        public ICollection<Film> GetRandomFilms(int amount)
        {
            return _context.Films.OrderBy(r => Guid.NewGuid()).Take(amount).ToList();
        }

        public ICollection<Film> GetFilmsByGenre(string genre)
        {
            return _context.FilmGenres.Where(g => g.Genre1 == genre).Select(f => f.Film).ToList();
        }

        public ICollection<Film> GetFilmsByTitle(string title)
        {
            return _context.Films.Where(f => EF.Functions.Like(f.Titel, "%"+title+"%")).ToList();
        }
    }
}
