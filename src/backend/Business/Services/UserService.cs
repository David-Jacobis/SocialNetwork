using Amazon.Runtime.Internal;
using Business.Interfaces;
using Business.ViewModels;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenAI.ObjectModels.SharedModels.IOpenAiModels;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
           
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            user.IndStaReg = "A";
            user.DatIniCad = DateTime.Now;
            user.DatUltAlt = DateTime.Now;
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            user.DatUltAlt = DateTime.Now;
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<User> GetUserByCodeAsync(string codeAceUsu)
        {
           return await _userRepository.GetUserByCodeAsync(codeAceUsu);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task CancelUserAsync(User user)
        {
            user.IndStaReg = "I";
            user.DatFimCad = DateTime.Now;
            user.DatUltAlt = DateTime.Now;
            await _userRepository.CancelUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }

            await _userRepository.DeleteUserAsync(id);
        }

    }
}
