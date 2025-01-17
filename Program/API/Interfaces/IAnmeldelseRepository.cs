using Api.Models;

namespace Api.Interfaces
{
    public interface IAnmeldelseRepository
    {
        /// <summary>
        /// Fetches rviews from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of reviews given to the Film.</returns>
        public ICollection<Anmeldelse> GetFilmAnmeldelser(int filmId);

        /// <summary>
        /// Fetches rviews from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of reviews made by the user.</returns>
        public ICollection<Anmeldelse> GetUserAnmeldelser(int anmelderId);
    }
}