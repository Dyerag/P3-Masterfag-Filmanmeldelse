using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Models;

namespace FilmAnmeldelseApi.Repository
{
    public class AnmeldelseRepository : IAnmeldelseRepository
    {
        private readonly DataContext _context;

        public AnmeldelseRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Anmeldelse> GetUserAnmeldelser(int id)
        {
            return _context.Anmeldelses.Where(a => a.AnmelderId == id).ToList();
        }

        public ICollection<Anmeldelse> GetFilmAnmeldelser(int id)
        {
            return _context.Anmeldelses.Where(a => a.FilmId == id).ToList();
        }
    }
}
