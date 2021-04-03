using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
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

        public IResult Add(Rental items)
        {
            if (items.RentDate == null || items.ReturnDate!=null)
            {
                    _rentalDal.Add(items);
                 return new SuccessResult(Message.Added);
            }
            else
            {
                return new ErrorResult(Message.NotAdded);
            }
            
        }

        public IResult Delete(Rental items)
        {
            _rentalDal.Delete(items);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental items)
        {
            _rentalDal.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
