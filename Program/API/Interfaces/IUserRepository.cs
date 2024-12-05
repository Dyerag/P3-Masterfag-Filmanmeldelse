using WebApp.model;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User?> ValidateLoginAsync(string brugernavn, string adgangskode);
        Task<bool> UserExistsAsync(string brugernavn);
        ICollection<User> GetUsersByUsername(string username);
    }
}
