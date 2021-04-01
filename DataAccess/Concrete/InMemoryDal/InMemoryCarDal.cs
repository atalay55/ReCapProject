using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryCarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {

                new Car {CarId=1,BrandId=1,ColorId=2,DailyPrice=250000,ModelYear=2018,Description="2018 Mercedes fullpaket " },
                new Car {CarId=2,BrandId=2,ColorId=1,DailyPrice=140000,ModelYear=2016,Description="2016 toyota corolla fullpaket " },
                new Car {CarId=3,BrandId=3,ColorId=3,DailyPrice=200000,ModelYear=2017,Description="2017 volvo fullpaket " },
                new Car {CarId=4,BrandId=1,ColorId=5,DailyPrice=170000,ModelYear=2016,Description="2016 Mercedes fullpaket " },
                new Car {CarId=5,BrandId=2,ColorId=7,DailyPrice=95000,ModelYear=2010,Description="2014 toyota fullpaket " },
                new Car {CarId=6,BrandId=2,ColorId=1,DailyPrice=750000,ModelYear=2010,Description="2010 toyota fullpaket " },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteToCar = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(deleteToCar);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {

            Car updateToCar = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            updateToCar.BrandId = car.BrandId;
            updateToCar.ColorId = car.ColorId;
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.Description = car.Description;

        }

        

    }
}
