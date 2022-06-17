using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _fileFolderName = "\\Images\\";




        public IResult Delete(string filePath)
        {
            DeleteOldImageFile(_currentDirectory + filePath);
           return new SuccessResult();
        }

        public IResult Update(IFormFile formFile, string carImage)
        {
            var checkFileExist = CheckFileExist(formFile);
            if(!checkFileExist.Success)
            {
                return new ErrorResult("File not updated");
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckOfTypeValid(type);
            var random = GuidHelper.CreateGuid();

            if(typeValid!=null)
            {
                return new ErrorResult(typeValid.Message);
            }
            DeleteOldImageFile(_currentDirectory+ carImage);
            CheckOfDirectory(_currentDirectory + _fileFolderName);
            CreateImageFile(formFile, _currentDirectory + _fileFolderName + random + type);
            return new SuccessResult((_fileFolderName + random + type).Replace("\\", "/"));
        }

        public IResult Upload(IFormFile formFile)
        {
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckOfTypeValid(type);
            var random = GuidHelper.CreateGuid();

            if(typeValid.Message!=null)
            {
                return new ErrorResult("File not upload");
            }
            CheckOfDirectory(_currentDirectory+_fileFolderName);
            CreateImageFile(formFile, _currentDirectory + _fileFolderName + random + type);
            return new SuccessResult((_fileFolderName + random + type).Replace("\\", "/"));

        }

        private static void CreateImageFile(IFormFile formFile, string directory )
        {
            using (FileStream fileStream = File.Create(directory) )
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }

        }

        private static void CheckOfDirectory(string directory)
        {
           if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static IResult CheckOfTypeValid(string type)
        {
            if(type!=".jpeg" && type!=".jpg" && type!=".png")
            {
                return new ErrorResult("Type is not valid");
            }
            return new SuccessResult();
        }
        private static void DeleteOldImageFile(string directory)
        {
            if(File.Exists(directory))
            {
                File.Delete(directory);
            }

        }
        private static IResult CheckFileExist(IFormFile formFile)
        {
           if(formFile!=null && formFile.Length>0)
            {
                return new  SuccessResult();
            }
            return new ErrorResult("FİLE NOT EXİST");
        }
    }
}
