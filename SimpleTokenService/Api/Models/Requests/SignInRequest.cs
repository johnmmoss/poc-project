using System.ComponentModel.DataAnnotations;

namespace SimpleTokenService.Api.Models.Requests
{
    public class SignInRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
