﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult DeleteCarById(int id);
        IResult Update(Car car);

        IResult AddTransactionalTest(Car car);

        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<List<Car>> GetCarByBrandId(int id);
        IDataResult<List<Car>> GetCarByColorId(int id);
        IDataResult<List<Car>> GetCarByBrandIdAndColorId(int brandId,int colorId);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
       
    }
}
