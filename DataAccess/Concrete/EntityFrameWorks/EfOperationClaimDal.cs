using Core.Concrete;
using Core.Entities.Entity;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWorks
{
    public class EfOperationClaimDal: EfEntityRepositoryBase<OperationClaim, RentalCarContext>,IOperationClaimDal
    {
    }
}
