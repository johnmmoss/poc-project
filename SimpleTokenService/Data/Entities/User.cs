using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SimpleTokenService.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string OfficeLocation { get; set; }

        public ICollection<Statement> Statements { get; set; }
    }
}
