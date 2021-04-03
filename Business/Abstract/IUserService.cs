﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityRespositoryService<User>
    {
    }
}
