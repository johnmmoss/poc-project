using SimpleTokenService.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTokenService.Domain.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string email, string password);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
