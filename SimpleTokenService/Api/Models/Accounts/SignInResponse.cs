namespace SimpleTokenService.Api.Models.Accounts
{
    public class SignInResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Expires { get; set; }
    }
}
