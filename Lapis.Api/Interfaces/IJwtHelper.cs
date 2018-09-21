using Lapis.DAL.Models;

namespace Lapis.Api.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateTokenStringForUser(User user);
    }
}