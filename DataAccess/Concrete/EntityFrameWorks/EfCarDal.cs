using Core.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWorks
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto , bool >>filter=null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var carDetails = from c in context.Carss join br in context.Brands
                                 on c.BrandId equals br.BrandId join co in context.Colors
                                 on c.ColorId equals co.ColorId select new CarDetailDto
                                 {
                                     CarId = c.Id,
                                     ColorId = co.ColorId,
                                     BrandId = br.BrandId,
                                     BrandName = br.BrandName,
                                     ColorName = co.ColorName,
                                     ModelYear = c.ModelYear,
                                     DailyPrice = c.DailyPrice,
                                     Description = c.Description,
                                     ImagePath = (from m in context.CarImages where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                                 };

                return filter == null ? carDetails.ToList() : carDetails.Where(filter).ToList();


            }
        }
    }
}
