using System;

namespace Core.Utilities.Security.Jwt
{

    public partial class JwtHelper
    {
        public class AccessToken
        {
            public string Token { get; set; }
            public DateTime Expiration { get; set; }
        }
    }
}
