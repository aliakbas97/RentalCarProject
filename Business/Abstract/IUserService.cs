using Core.Entities.Entity;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {

        IDataResult<List<OperationClaim>> GetClaims(User user);


        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserByFirstName(string name);
        IDataResult<User> GetUserByEmail(string email);
    }
}
