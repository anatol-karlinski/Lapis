using Lapis.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapis.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
