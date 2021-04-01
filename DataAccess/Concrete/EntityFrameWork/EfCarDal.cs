using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EFRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                            select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }


    }

}

