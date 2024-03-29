﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns
{
   public static class ValidationTool 
    {

        public static void Validate(IValidator validator ,object obje)
        {
            var context = new ValidationContext<object>(obje);
            var result = validator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
