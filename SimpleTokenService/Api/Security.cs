using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SimpleTokenService.Api
{
    public static class Security
    {    
        private static string SECURITY_KEY = "cffad38e-b5de-436b-b66c-ee9ad370801a"; 

        public static SymmetricSecurityKey SymmetricSecurityKey 
        {
            get
            {
                var keyInBytes = Encoding.ASCII.GetBytes(SECURITY_KEY);

                return new SymmetricSecurityKey(keyInBytes);
            }
        }
    }
}