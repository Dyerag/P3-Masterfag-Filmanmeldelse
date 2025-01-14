using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Interfaces;
using WebApp.model;

namespace FilmAnmeldelseApi.services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        //TODO burde ligge i FilmController
        public List<SearchFilmDto> SearchFilmsByTitle(string title)
        {
            var films = _filmRepository.GetFilmsByTitle(title);
            return films.Select(f => new SearchFilmDto
            {
                Id = f.Id,
                Titel = f.Titel,
                Plakat = f.Plakat
            }).ToList();
        }
    }
}
