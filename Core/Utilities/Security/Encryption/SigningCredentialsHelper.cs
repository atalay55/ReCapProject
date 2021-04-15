using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public partial class SecurityKeyHelper
    {
        public class SigningCredentialsHelper
        {
            public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
            {
                return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            }
        }
    }
}