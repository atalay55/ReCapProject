using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
  
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[SecuredOperation("user,admin")]
        [CacheAspect]
        [PerformanceAspect(60)]
        public IDataResult<List<Car>>  GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Message.DataListted);
        }



        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Message.Added);
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.Deleted);

        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.Updated);
        }

        [CacheAspect]
        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetbyUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(  _carDal.GetAll(p => p.DailyPrice <= max && p.DailyPrice >= min),Message.listted);
        }


        [CacheAspect]
        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetbyBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == brandId),Message.listted);
        }

        [CacheAspect]
        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.ColorId == colorId),Message.listted);
        }


        [CacheAspect]
        [SecuredOperation("user,admin")]
        public IDataResult<List<CarDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetDetails(),Message.listted);

        }
    }
}