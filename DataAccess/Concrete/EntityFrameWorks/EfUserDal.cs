using Core.Concrete;
using Core.Entities.Entity;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace DataAccess.Concrete.EntityFrameWorks
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentalCarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from o in context.OperationClaims 
                             join u in context.UserOperationClaims
                             on o.OperationClaimId equals  u.OperationClaimId
                             where u.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = o.OperationClaimId, Name = o.Name };
                return result.ToList();



            }
        }
    }
}
