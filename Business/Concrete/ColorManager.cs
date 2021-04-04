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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

       
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll(),Message.DataListted);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Message.Updated);
        }
    }
}
