using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand items)
        {
            _brandDal.Add(items);

            return new SuccessResult(Message.Added);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand items)
        {
            _brandDal.Delete(items);
            return new SuccessResult(Message.Deleted);
        }


        [CacheAspect]
        
        [SecuredOperation("user")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Message.DataListted);
        }


        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand items)
        {
            _brandDal.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
