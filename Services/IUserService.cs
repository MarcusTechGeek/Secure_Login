using System.Collections.Generic;
using System.Threading.Tasks;
using SecureLogin.Models;
using BCrypt.Net;

namespace SecureLogin.Services
{
    // Interface for user-related operations.
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(); // Get all users asynchronously.
        Task<User> GetUserByIdAsync(int id); // Get a user by ID asynchronously.
        Task<bool> AddUserAsync(User user); // Add a new user asynchronously.
        Task<bool> UpdateUserAsync(User user); // Update a user asynchronously.
        Task<bool> RemoveUserAsync(int id); // Remove a user by ID asynchronously.
        Task<List<User>> SearchUsersAsync(string searchTerm); // Search users asynchronously.
    }
}
