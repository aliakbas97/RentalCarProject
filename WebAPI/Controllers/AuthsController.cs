using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        
            private IAuthService _authService;

            public AuthsController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public ActionResult Login(UserForLoginDto userForLoginDto)
            {
                var userToLogin = _authService.Login(userForLoginDto);
                if (!userToLogin.Success)
                {
                    return BadRequest(userToLogin.Message);
                }

                var result = _authService.CreateAccessToken(userToLogin.Data);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }

            [HttpPost("register")]
            public ActionResult Register(UserForRegisterDto userForRegisterDto)
            {
                var userExists = _authService.UserExist(userForRegisterDto.Email);
                if (userExists.Success)
                {
                    return BadRequest(Messages.UserNotRegister);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Message);
            }
        }
}
