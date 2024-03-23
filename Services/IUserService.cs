using System.Collections.Generic;
using System.Threading.Tasks;
using SecureLogin.Models;
using BCrypt.Net;

namespace SecureLogin.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> RemoveUserAsync(int id);
        Task<List<User>> SearchUsersAsync(string searchTerm);
    }
}