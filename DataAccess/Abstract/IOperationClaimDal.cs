using Core.DataAccess.Abstract;
using Core.Entities.Entity;
using DataAccess.Concrete.EntityFrameWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IOperationClaimDal:IEntityRepository<OperationClaim>
    {
    }
}
