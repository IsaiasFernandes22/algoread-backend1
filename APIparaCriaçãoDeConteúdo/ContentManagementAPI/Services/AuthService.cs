using System;
using System.Threading.Tasks;
using BCrypt.Net;
using ContentManagementAPI.Models;
using ContentManagementAPI.Repositories;

namespace ContentManagementAPI.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(string email, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null)
            {
                throw new Exception("User already exists.");
            }

            var user = new User
            {
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password) // Certifique-se de que a biblioteca BCrypt está instalada.
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            return user;
        }
    }
}
