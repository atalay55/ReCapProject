using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result =carManager.Add(new Entities.Concrete.Car {BrandId=2,CarName="a",ColorId=1,DailyPrice=2554, });
            Console.WriteLine(result.Message);
            foreach (  var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
