using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,moderator,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
          _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult DeleteCarById(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheAspect] // key ,value
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> ( _carDal.GetAll(),Messages.CarsListed);
        }
        //[PerformanceAspect(5)]
        public IDataResult<List<Car>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public  IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.DailyPrice >min && c.DailyPrice<max));
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);


        }


    }
}
