using WebApp.model;

namespace FilmAnmeldelseApi.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user);
    }
}
