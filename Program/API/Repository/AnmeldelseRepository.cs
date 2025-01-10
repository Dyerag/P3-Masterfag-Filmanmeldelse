using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repository
{
    public class AnmeldelseRepository : IAnmeldelseRepository
    {
        private readonly DataContext _context;

        public AnmeldelseRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returnerer en liste af anmedelser tilhørende en bruger
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Anmeldelse> GetUserAnmeldelser(int id)
        {
            return _context.Anmeldelses.Where(a => a.AnmelderId == id).ToList();
        }

        /// <summary>
        /// Returnerer en liste af anmeldelser tilhørende en film
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Anmeldelse> GetFilmAnmeldelser(int id)
        {
            return _context.Anmeldelses.Where(a => a.FilmId == id).ToList();
        }

        public bool AnmeldelserExists(int id)
        {

        }
    }
}
