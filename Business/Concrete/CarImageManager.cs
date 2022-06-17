using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

      

        public IResult Delete(CarImage carImage)
        {

            var imageDelete = _carImageDal.Get(c => c.ImageId == carImage.ImageId);

           
            _carImageDal.Delete(imageDelete);
            return new SuccessResult(Messages.ImageDeleted);
;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
           return new SuccessDataResult<List<CarImage>>( _carImageDal.GetAll());

        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carid)
        {
            IResult results = BusinessRules.Run(CheckImageNull(carid));
            if(!results.Success)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carid));
            }
            return new SuccessDataResult<List<CarImage>>(CheckImageNull(carid).Data);
            
        }

        public IResult Update(IFormFile formFile,CarImage carImage)
        {
            if(carImage==null)
            {
                return new ErrorResult("car image is null");
            }
            var imageFileUpdate = _fileHelper.Update(formFile,carImage.ImagePath);
            if(!imageFileUpdate.Success)
            {
                return new ErrorResult(imageFileUpdate.Message);
            }

            carImage.ImagePath = imageFileUpdate.Message;
           
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.ImageUpdated);
        }

        private  IResult CheckImageCount(CarImage carImage)
        {
            var ImageCount = _carImageDal.GetAll(c => c.CarId ==carImage.CarId);
            if(ImageCount.Count>5)
            {
                return new ErrorResult(Messages.ImageCountOverLimit);
            }
            return new SuccessResult();
        }
        private  IDataResult<List<CarImage>> CheckImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if(!result)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage
                {
                    CarId = id,
                    Date = DateTime.Now,
                    ImagePath = path
                });
                return new SuccessDataResult<List<CarImage>>(carImages);
                    
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));

        }

        public IResult Upload(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageCount(carImage));
            if(result!=null)
            {
                return result;
            }
            var imageResult = _fileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImageAdded);
        }
    }
}
