using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }



        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var createToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(createToken,Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {

            var checkForEmail = _userService.GetUserByEmail(userForLoginDto.Email);
            if (checkForEmail == null)
            {
                return new ErrorDataResult<User>(Messages.userNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, checkForEmail.Data.PasswordHash, checkForEmail.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(checkForEmail.Data,Messages.userWrongPassword);
            }
            return new SuccessDataResult<User>(checkForEmail.Data, Messages.UserMailFound);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true


            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetUserByEmail(email) == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
    }
}
