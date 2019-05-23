namespace SimpleTokenService.Api.Models.Responses
{
    public class SignInResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Expires { get; set; }
    }
}
