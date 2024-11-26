using FilmAnmeldelseApi.Models;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IAnmeldelseRepository
    {
        public ICollection<Anmeldelse> GetFilmAnmeldelser(int filmId);

        public Anmeldelse GetAnmeldelse(int filmId, int anmelderId);
    }
}