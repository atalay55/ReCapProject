using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorService _colorService;

        public ColorManager(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IResult Add(Color items)
        {
            _colorService.Add(items);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Color items)
        {
            _colorService.Delete(items);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorService.GetAll().Data,Message.DataListted);
        }

        public IResult Update(Color items)
        {
            _colorService.Update(items);
            return new SuccessResult(Message.Updated);
        }
    }
}
