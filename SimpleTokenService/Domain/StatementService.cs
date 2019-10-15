using System.Threading.Tasks;
using SimpleTokenService.Data.Entities;
using System.Linq;
using System.Collections.Generic;

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
            var users = await _userRepository.FindByAsync(x => x.NormalizedEmail == email.ToUpper(), x => x.Statements);

            var user = users.FirstOrDefault();

            if (user == null)
            {
                // Euston, we have a problem!
            }

            statement.UserId = user.Id;

            await _statementRepository.CreateAsync(statement);
        }

        public async Task<IEnumerable<Statement>> GetAllByEmailAddress(string emailAddress)
        {
            var normalizedEmailAddress = emailAddress.ToUpper();

            return await _statementRepository.FindByAsync(x => x.User.NormalizedEmail == normalizedEmailAddress);
        }

        public async Task<Statement> GetById(int id)
        {
            var result = await _statementRepository.FindByAsync(x => x.Id == id);

            return result.FirstOrDefault(); 
        }

        public async Task Update(Statement newEntity)
        {
            var current = (await _statementRepository.FindByAsync(x => x.Id == newEntity.Id)).FirstOrDefault();

            current.Title = newEntity.Title;
            current.EndDate = newEntity.EndDate;
            current.StartDate = newEntity.StartDate;
            current.OpeningBalance = newEntity.OpeningBalance;

            await _statementRepository.UpdateAsync(current);
        }
    }
}
