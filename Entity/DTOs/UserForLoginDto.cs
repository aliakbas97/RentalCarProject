﻿using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
   public class UserForLoginDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
