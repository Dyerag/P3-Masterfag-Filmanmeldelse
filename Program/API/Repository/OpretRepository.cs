using WebApp.model;
using Microsoft.EntityFrameworkCore;
using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;

namespace FilmAnmeldelseApi.Repository
{
    public class OpretRepository : IUserRepository
    {
        private readonly FilmAnmeldelseContext _context;

        public OpretRepository(FilmAnmeldelseContext context) => _context = context;

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
    }
}
