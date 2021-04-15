using System.Collections.Generic;
using Core.Entities.Concrete;
using static Core.Utilities.Security.Jwt.JwtHelper;

namespace Core.Utilities.Security.Jwt
{
        public interface ITokenHelper
        {
            AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        }
    
}
