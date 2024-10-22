using DataAccess.Context;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _dbContext;

        public UserRepository(MainContext MainContext)
        {
            _dbContext = MainContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.TabMapUsuarios.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.TabMapUsuarios.OrderBy(x => x.IdUsu).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _dbContext.TabMapUsuarios.FirstAsync(x => x.IdUsu == Id);
        }

        public async Task<User> GetUserByCodeAsync(string codeAceUsu)
        {
            return await _dbContext.TabMapUsuarios.FirstOrDefaultAsync(x => x.CodAceUsu == codeAceUsu);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.TabMapUsuarios.FirstOrDefaultAsync( x => x.DesEmailUsu == email);
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.TabMapUsuarios.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CancelUserAsync(User user)
        {
            _dbContext.TabMapUsuarios.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int Id)
        {
            var itemDelete = await _dbContext.TabMapUsuarios.FindAsync(Id);

            if (itemDelete != null)
            {
                _dbContext.TabMapUsuarios.Remove(itemDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
