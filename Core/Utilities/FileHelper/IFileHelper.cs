using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.FileHelper
{
  public  interface IFileHelper
    {
        IResult Upload(IFormFile formFile);
        IResult Delete(string filePath);
        IResult Update(IFormFile formFile, string carImage);


        
    }
}
