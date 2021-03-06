using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer items)
        {
            _customerDal.Add(items);
            return new SuccessResult(Message.Added);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Customer items)
        {
            _customerDal.Delete(items);
            return new SuccessResult(Message.Deleted);
        }


        [SecuredOperation("admin")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }




        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer items)
        {
            _customerDal.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
