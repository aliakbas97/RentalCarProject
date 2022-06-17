using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("addimage")]
        public IActionResult Upload([FromForm(Name =("Images"))] IFormFile formFile ,[FromForm] CarImage carImage)
        {

            var result = _carImageService.Upload(formFile, carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallimages")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if(!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesByCarId(int id)
        {
            var result = _carImageService.GetCarImagesByCarId(id);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatecarimages")]
        public IActionResult Update([FromForm(Name ="Images")] IFormFile formFile, [FromForm]  CarImage carImage)
        {
            var result = _carImageService.Update(formFile,carImage);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletecarimages")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete( carImage);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
