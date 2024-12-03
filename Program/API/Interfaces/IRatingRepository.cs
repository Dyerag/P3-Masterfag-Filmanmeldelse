//using FilmAnmeldelseApi.Models; < -brug den senere
using WebApp.model;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IRatingRepository
    {
        public ICollection<Anmeldelse> GetFilmRatings(int filmId);

    }
}
