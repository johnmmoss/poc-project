using SimpleTokenService.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTokenService.Domain
{
    public interface IStatementService
    {
        Task Add(string email, Statement statement);

        Task<IEnumerable<Statement>> GetAllByEmailAddress(string emailAddress);

        Task<Statement> GetById(int id);
        Task Update(Statement newEntity);
    }
}
