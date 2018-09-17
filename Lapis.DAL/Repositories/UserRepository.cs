using Lapis.DAL.Abstracts.Patterns;
using Lapis.DAL.Interfaces;
using Lapis.DAL.Models;
using System.Threading.Tasks;

namespace Lapis.DAL.Repositories
{
    public class UserRepository : RepositoryAbstract<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
        }
    }
}
