using FilmAnmeldelseApi.Dto;
using FilmAnmeldelseApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmAnmeldelseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IUserService _userService;

        public SearchController(IFilmService filmService, IUserService userService)
        {
            _filmService = filmService;
            _userService = userService;
        }

        //TODO det her findes allerede
        /// <summary>
        /// Søger efter film baseret på titel.
        /// </summary>
        /// <param name="title">Titlen, der skal søges efter.</param>
        /// <returns>En liste af film, der matcher søgeteksten.</returns>
        [HttpGet("films/{title}")]
        public IActionResult SearchFilms(string title)
        {
            var films = _filmService.SearchFilmsByTitle(title);

            if (films == null || films.Count == 0)
                return NotFound("Ingen film fundet med den angivne titel.");

            return Ok(films);
        }

        //TODO Dette kald burde være i en controller dedikeret til User 
        /// <summary>
        /// Søger efter brugere baseret på brugernavn.
        /// </summary>
        /// <param name="username">Brugernavn, der skal søges efter.</param>
        /// <returns>En liste af brugere, der matcher søgeteksten.</returns>
        [HttpGet("users/{username}")]
        public IActionResult SearchUsers(string username)
        {
            var users = _userService.SearchUsersByUsername(username);

            //TODO Hvorfor bruger du både count og null?
            if (users == null || users.Count == 0)
                return NotFound("Ingen brugere fundet med det angivne brugernavn.");

            return Ok(users);
        }

        
    }
}
