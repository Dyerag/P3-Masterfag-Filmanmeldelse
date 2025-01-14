using FilmAnmeldelseApi.Interfaces;
using WebApp.model;
using FilmAnmeldelseApi.Dto;

namespace WebApp.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        //TODO kunne barer havde været del af controlleren
        /// <summary>
        /// Tilføjer en ny bruger, hvis brugernavnet ikke allerede findes.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> RegisterUserAsync(User user)
        {
            //TODO Alt tjekket gør er at kaste en exception hvis navnet allerede bruges
            // Tjek om brugernavnet allerede findes
            if (await _repository.UserExistsAsync(user.Brugernavn))
            {
                throw new Exception("Brugernavnet findes allerede.");
            }
            
            //TODO Selv hvis brugerenavnet er taget, giver du alligevel en oprettelsesdato. Unødvendigt, siden databasen selv giver en oprettelses dato hvis ingen er angivet
            // Sæt oprettelsesdato
            user.Oprettelsesdato = DateOnly.FromDateTime(DateTime.Now);

            //TODO Selv hvis brugernavnet er i brug, vil der prøves at tilføje brugeren til databasen
            // Tilføj brugeren til databasen
            return await _repository.AddUserAsync(user);
        }

        //TODO Det hele burde havde været en del af controlleren
        /// <summary>
        /// Validerer loginoplysninger og returnerer brugeren, hvis de er korrekte.
        /// </summary>
        /// <param name="brugernavn"></param>
        /// <param name="adgangskode"></param>
        /// <returns></returns>
        public async Task<User?> LoginAsync(string brugernavn, string adgangskode)
        {
            // Valider login-oplysninger via repository
            var user = await _repository.ValidateLoginAsync(brugernavn, adgangskode);

            if (user == null)
            {
                throw new Exception("Forkert brugernavn eller adgangskode.");
            }

            return user;
        }

        //TODO Burde ligge i controlleren
        /// <summary>
        /// Søger efter brugere baseret på brugernavn.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<SearchUserDto> SearchUsersByUsername(string username)
        {
            var users = _repository.GetUsersByUsername(username);
            return users.Select(u => new SearchUserDto
            {
                Id = u.Id,
                Brugernavn = u.Brugernavn,
                Billede = u.Billede
            }).ToList();
        }
    }
}
