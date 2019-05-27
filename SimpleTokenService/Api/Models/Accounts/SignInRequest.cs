using System.ComponentModel.DataAnnotations;

namespace SimpleTokenService.Api.Models.Accounts
{
    public class SignInRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
