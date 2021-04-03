using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User items)
        {
            _userDal.Add(items);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(User items)
        {
            _userDal.Delete(items);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User items)
        {
            _userDal.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
