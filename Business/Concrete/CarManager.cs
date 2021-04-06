using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    [ValidationAspect(typeof(CarValidator))]
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>>  GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Message.DataListted);
        }

     
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Message.Added);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.Deleted);

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Car>> GetbyUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(  _carDal.GetAll(p => p.DailyPrice <= max && p.DailyPrice >= min),Message.listted);
        }

        public IDataResult<List<Car>> GetbyBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == brandId),Message.listted);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(p => p.ColorId == colorId),Message.listted);
        }

        public IDataResult<List<CarDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetDetails(),Message.listted);

        }
    }
}