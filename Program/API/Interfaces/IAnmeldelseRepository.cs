using Api.Models;

namespace Api.Interfaces
{
    public interface IAnmeldelseRepository
    {
        /// <summary>
        /// Returnerer en liste af anmeldelser tilhørende en film
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Anmeldelse> GetFilmAnmeldelser(int filmId);

        /// <summary>
        /// Returnerer en liste af anmedelser tilhørende en bruger
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICollection<Anmeldelse> GetUserAnmeldelser(int anmelderId);
    }
}