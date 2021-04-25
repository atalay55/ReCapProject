using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    
    
    public class RentalManager : IEntityRespositoryService<Rental>, IRentalService
    {
        IRentalDal _rentalDal;
        IEntity _entity;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public RentalManager(IEntity entity)
        {
            _entity = entity;
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (rental.RentDate == null || rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.Added);
            }
            else
            {
                return new ErrorResult(Message.NotAdded);
            }

        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.Deleted);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.Updated);
        }
    }
}
