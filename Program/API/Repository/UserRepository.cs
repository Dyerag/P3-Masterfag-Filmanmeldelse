using WebApp.model;
using Microsoft.EntityFrameworkCore;
using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;

namespace FilmAnmeldelseApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmAnmeldelseContext _context;

        public UserRepository(FilmAnmeldelseContext context) => _context = context;

        /// <summary>
        /// Tilføjer en ny bruger til databasen.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Validerer brugerens loginoplysninger.
        /// </summary>
        /// <param name="brugernavn"></param>
        /// <param name="adgangskode"></param>
        /// <returns></returns>
        public async Task<User?> ValidateLoginAsync(string brugernavn, string adgangskode)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>
                u.Brugernavn == brugernavn && u.Adgangskode == adgangskode);
        }

        /// <summary>
        /// Tjekker, om brugernavnet allerede findes.
        /// </summary>
        /// <param name="brugernavn"></param>
        /// <returns></returns>
        public async Task<bool> UserExistsAsync(string brugernavn)
        {
            return await _context.Users.AnyAsync(u => u.Brugernavn == brugernavn);
        }

        /// <summary>
        /// Søger efter brugere baseret på brugernavn (case insensitive).
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public ICollection<User> GetUsersByUsername(string username)
        {
            return _context.Users
                .Where(u => EF.Functions.Like(u.Brugernavn, $"%{username}%"))
                .ToList();
        }
    }
}
