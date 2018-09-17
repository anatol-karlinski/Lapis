using Lapis.DAL.Interfaces.Patterns;
using Lapis.DAL.Models;
using System.Threading.Tasks;

namespace Lapis.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
