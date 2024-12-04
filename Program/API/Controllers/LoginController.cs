using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApp.model;
using FilmAnmeldelseApi.Data;

namespace FilmAnmeldelseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("User")]
        public IActionResult GetUser()
        {
            using (var context = new FilmAnmeldelseContext())
            {
                var users = context.Users.ToList();

                return Ok(users);
            }
        }


            /// <summary>
            /// Endpoint til at oprette en ny bruger.
            /// </summary>
            /// <param name="dto"></param>
            /// <returns></returns>
            [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] OpretDto dto)
        {
            try
            {
                // Konverter DTO til User-model
                var newUser = new User
                {
                    Brugernavn = dto.Brugernavn,
                    Adgangskode = dto.Adgangskode
                };

                // Opret bruger via service
                var createdUser = await _userService.RegisterUserAsync(newUser);

                // Returner succes med brugeren (uden adgangskode for sikkerhed)
                return Ok(new
                {
                    createdUser.Id,
                    createdUser.Brugernavn,
                    createdUser.Oprettelsesdato
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}