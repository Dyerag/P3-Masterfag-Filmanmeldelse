using FilmAnmeldelseApi.Models;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IRatingRepository
    {
        public ICollection<Anmeldelser> GetFilmRatings(int filmId);

    }
}
