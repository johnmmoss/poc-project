using Microsoft.EntityFrameworkCore;
using SimpleTokenService.Data;
using System.IO;
using System.Reflection;

namespace SimpleTokenService.Api.Integration.Tests
{
    public class TestDatabase
    {
        public void Setup()
        {
            var connectionString = "Server=(local)\\sqlexpress;Initial Catalog=SimpleTokenService;Persist Security Info=False; integrated security=True";
            var optionsBuilder = new DbContextOptionsBuilder<TokenContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var insertSqlPath = Path.Combine(sourceDirectory, "TestData.sql");
            var insertSql = File.ReadAllText(insertSqlPath);

            using (var tokenContext = new TokenContext(optionsBuilder.Options))
            {
                var users = tokenContext.Users.ToListAsync().Result;

                tokenContext.Database.ExecuteSqlCommand("delete from [User]");
                tokenContext.Database.ExecuteSqlCommand(insertSql);
            }
        }
    }
}
