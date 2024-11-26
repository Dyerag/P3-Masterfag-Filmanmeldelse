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

        public Anmeldelse GetAnmeldelse(int filmId, int anmelderId)
        {
            return _context.Anmeldelses.Where(a => a.FilmId == filmId && a.AnmelderId == anmelderId).FirstOrDefault();
        }

        public ICollection<Anmeldelse> GetFilmAnmeldelser(int filmId)
        {
            return _context.Anmeldelses.Where(a => a.FilmId == filmId).ToList();
        }
    }
}
