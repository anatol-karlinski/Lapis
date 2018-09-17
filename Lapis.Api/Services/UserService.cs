using Lapis.Api.Helpers;
using Lapis.Api.Interfaces;
using Lapis.Api.Models;
using Lapis.DAL.Interfaces;
using Lapis.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lapis.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetById(int id)
        {
            return _userRepository.GetWhere(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _userRepository.GetFirst(u => u.Username == username);

            if (user == null || !PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            var existingUser = await _userRepository.GetFirstAsync(u => u.Username == user.Username);

            if (existingUser != null)
            {
                throw new AppException("Username " + user.Username + " is already taken");
            }

            PasswordHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateAsync(User userParam, string password = null)
        {
            var user = await _userRepository.GetFirstAsync(u => u.Id == userParam.Id);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;

            if (!string.IsNullOrWhiteSpace(password))
            {
                PasswordHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            return await _userRepository.UpdateAsync(user);
        }


        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<string>> GetRolesAsync(User user)
        {
            return await Task.FromResult<List<string>>(MocUserRoles());
        }

        private List<string> MocUserRoles()
        {
            return new List<string>
                {
                    "User"
                };
        }
    }
}