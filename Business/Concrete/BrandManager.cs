using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandService _brandService;

        public BrandManager(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IResult Add(Brand items)
        {
            _brandService.Add(items);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Brand items)
        {
            _brandService.Delete(items);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _brandService.GetAll().Data,Message.DataListted);
        }

        public IResult Update(Brand items)
        {
            _brandService.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
