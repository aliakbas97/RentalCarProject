using Core.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWorks
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var carDetails= from c in context.Carss join br in context.Brands
                                on c.BrandId equals br.BrandId join co in context.Colors
                                on c.ColorId equals co.ColorId select new CarDetailDto 
                                {CarId=c.Id ,  BrandName=br.BrandName, ColorName=co.ColorName, DailyPrice=c.DailyPrice };

                return carDetails.ToList();


            }
        }
    }
}
