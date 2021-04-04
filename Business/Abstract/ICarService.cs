using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICarService:IEntityRespositoryService<Car>
    {
        IDataResult<List<CarDetailDto>> GetDetails();
        IDataResult<List<Car>> GetbyUnitePrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetbyBrandId(int brandId);
    }
}
