using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityRespositoryService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
