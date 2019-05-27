using System.Threading.Tasks;
using SimpleTokenService.Data.Entities;
using System.Linq;

namespace SimpleTokenService.Domain
{
    public class StatementService : IStatementService
    {
        private readonly IGenericRepository<Statement> _statementRepository;
        private readonly IGenericRepository<User> _userRepository;

        public StatementService(IGenericRepository<Statement> statementRepository, IGenericRepository<User> userRepository)
        {
            _statementRepository = statementRepository;
            _userRepository = userRepository;
        }

        public async Task Add(string email, Statement statement)
        {
            var users =  await _userRepository.FindByAsync(x => x.NormalizedEmail == email.ToUpper(), x => x.Statements);

            var user = users.FirstOrDefault();

            if (user == null)
            {
                // Euston, we have a problem!
            }

            statement.UserId = user.Id;

            await _statementRepository.CreateAsync(statement);
        }
    }
}
