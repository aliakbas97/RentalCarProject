using Core.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWorks
{
  public  class EfRentalDal :EfEntityRepositoryBase<Rental,RentalCarContext>,IRentalDal
    {
    }
}
