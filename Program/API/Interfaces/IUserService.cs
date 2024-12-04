using WebApp.model;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);

        Task<User> LoginAsync(string brugernavn, string adgangskode);
    }
}
