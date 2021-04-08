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

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //userManager.Add(new Entities.Concrete.User {FirstName="Barış",LastName="Adana",Password="126458" });
            var result = rentalManager.Add(new Entities.Concrete.Rental { CustomerId = 3, CarId = 4, RentDate = new DateTime(2020, 3, 1) } );

            //userManager.Add(new Entities.Concrete.User { FirstName="Sergen",LastName="Kral",Password="234567"});


          









            //var result =carManager.Add(new Entities.Concrete.Car {BrandId=2,CarName="a",ColorId=1,DailyPrice=2554, });
            //Console.WriteLine(result.Message);
            //foreach (  var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(car.CarName);
            //}
        }
    }
}
