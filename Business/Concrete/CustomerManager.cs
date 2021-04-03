﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer items)
        {
            _customerDal.Add(items);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Customer items)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Update(Customer items)
        {
            throw new NotImplementedException();
        }
    }
}
