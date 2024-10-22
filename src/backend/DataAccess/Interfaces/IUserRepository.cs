using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task<User> GetUserByCodeAsync(string codeAceUsu);
        Task<User> GetUserByEmail(string email);
        Task UpdateUserAsync(User user);
        Task CancelUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
