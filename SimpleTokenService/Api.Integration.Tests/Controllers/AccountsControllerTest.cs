using System.Net;
using Xunit;

namespace SimpleTokenService.Api.Integration.Tests.Controllers
{
    public class AccountsControllerTest
    {

        private string api_base = "http://localhost/StatementsTracker.Api/api";
        private TestHttpClient _testHttpClient;

        public AccountsControllerTest()
        {
            _testHttpClient = new TestHttpClient();
            var testDatabase = new TestDatabase();

            testDatabase.Setup();
        }

        [Fact]
        public void A_user_with_valid_credentials_can_get_an_access_token()
        {
            var loginRequestData = new
            {
                emailaddress = "johnmmoss@gmail.com",
                password = "Password1!"
            };

            var accountsSigninUrl = $"{api_base}/accounts/signin";

            var (status, responseContent) = _testHttpClient.Post(accountsSigninUrl, loginRequestData);

            Assert.Equal(HttpStatusCode.OK, status);
            Assert.True(responseContent.success.Value);
            Assert.False(string.IsNullOrEmpty(responseContent.token.Value));
        }

        [Fact]
        public void A_user_with_invalid_credentials_gets_empty_response_object()
        {
            var loginRequestData = new
            {
                emailaddress = "ASDFasdf",
                password = "my password"
            };

            var accountsSigninUrl = $"{api_base}/accounts/signin";

            var (status, responseContent) = _testHttpClient.Post(accountsSigninUrl, loginRequestData);

            Assert.Equal(HttpStatusCode.OK, status);
            Assert.False(responseContent.success.Value);
            Assert.True(string.IsNullOrEmpty(responseContent.token.Value));
        }
    }
}
