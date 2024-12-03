using FilmAnmeldelseApi.Interfaces;
using WebApp.model;
using FilmAnmeldelseApi;

namespace WebApp.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Tilføjer en ny bruger, hvis brugernavnet ikke allerede findes.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> RegisterUserAsync(User user)
        {
            // Tjek om brugernavnet allerede findes
            if (await _repository.UserExistsAsync(user.Brugernavn))
            {
                throw new Exception("Brugernavnet findes allerede.");
            }

            // Sæt oprettelsesdato
            user.Oprettelsesdato = DateOnly.FromDateTime(DateTime.Now);

            // Tilføj brugeren til databasen
            return await _repository.AddUserAsync(user);
        }
    }
}
