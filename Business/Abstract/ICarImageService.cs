using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IResult Upload(IFormFile formFile , CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult DeleteImageByImageId(int id);
        IResult Update(IFormFile formFile,CarImage carImage);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carid);
        IDataResult<List<CarImage>> GetDefaultImage(int carId);
    }
}
