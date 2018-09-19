using Lapis.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lapis.Api.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<User> CreateAsync(User user, string password);
        IEnumerable<User> GetById(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User userParam, string password = null);
        Task DeleteAsync(int id);
    }
}
