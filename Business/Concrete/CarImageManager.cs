using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities;
using Core.Utilities.FlieHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    

        public class CarImageManager : ICarImageService
        {

            ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

            public IResult Add(CarImage carImage, IFormFile file)
            {
                IResult result = BusinessRule.Run(CheckImageLimited(carImage.CarId));
                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Message.Added);
            }

            public IResult Delete(CarImage carImage)
            {
           
                FileHelper.Delete(carImage.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult();
          


            }

            public IDataResult<CarImage> Get(int id)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
            }

            public IDataResult<List<CarImage>> GetAll()
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Message.listted);

            }

            public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
            {
                var result = _carImageDal.GetAll(c => c.CarId == CarId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = CarId, ImagePath = @"\Images\default.png" });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
            }

            [ValidationAspect(typeof(CarImageValidator))]
            public IResult Update(CarImage carImage, IFormFile file)
            {
                var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.CarId).ImagePath;

                carImage.ImagePath = FileHelper.Update(oldPath, file);
                carImage.Date = DateTime.Now;
                _carImageDal.Update(carImage);
                return new SuccessResult();

            }
            private IResult CheckImageLimited(int carId)
            {
                var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
                if (carImageCount >= 5)
                {
                    return new ErrorResult(Message.ErrorByImageCount);
                }
                return new SuccessResult();
            }
        }
    }
