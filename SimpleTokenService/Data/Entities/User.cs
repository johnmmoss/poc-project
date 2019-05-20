using Microsoft.AspNetCore.Identity;

namespace SimpleTokenService.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string OfficeLocation { get; set; }
    }
}
