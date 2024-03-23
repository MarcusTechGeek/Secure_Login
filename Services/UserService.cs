using SecureLogin.Data;
using SecureLogin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCryptAlias = BCrypt.Net.BCrypt;

namespace SecureLogin.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            // Hash the password using bcrypt if it's not null
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = BCryptAlias.HashPassword(user.PasswordHash);
            }

            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            // Hash the password using bcrypt if it has changed and is not null
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = BCryptAlias.HashPassword(user.PasswordHash);
            }

            _context.Entry(user).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<User>> SearchUsersAsync(string searchTerm)
        {
            return await _context.Users
                .Where(u => !string.IsNullOrEmpty(u.Email) && u.Email.Contains(searchTerm))
                .ToListAsync();
        }
    }
}