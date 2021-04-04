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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand items)
        {
            _brandDal.Add(items);

            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Brand items)
        {
            _brandDal.Delete(items);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Message.DataListted);
        }

        public IResult Update(Brand items)
        {
            _brandDal.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
