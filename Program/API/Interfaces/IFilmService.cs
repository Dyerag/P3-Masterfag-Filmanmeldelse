using FilmAnmeldelseApi.Dto;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IFilmService
    {
        List<SearchFilmDto> SearchFilmsByTitle(string title);
    }
}