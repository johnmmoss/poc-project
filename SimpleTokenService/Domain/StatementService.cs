using System.Threading.Tasks;
using SimpleTokenService.Data.Entities;

namespace SimpleTokenService.Domain
{
    public class StatementService : IStatementService
    {
        private readonly IGenericRepository<Statement> _statementRepository;

        public StatementService(IGenericRepository<Statement> statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task Add(Statement statement)
        {
            await _statementRepository.CreateAsync(statement);
        }
    }
}
