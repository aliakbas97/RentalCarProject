using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;

using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

           

            var result = _carService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }
           
            return BadRequest(result);
           
        }
       
        [HttpPost("addcar")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecarbycarid")]
        public IActionResult DeleteCarByCarId(int id)
        {
            var result = _carService.DeleteCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("updatecar")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarByBrandId(int id)
        {
            var result = _carService.GetCarByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("getcarsbydailyprice")]
        public IActionResult GetCarByDailyPrice(decimal min, decimal max)
        {
            var result = _carService.GetCarsByDailyPrice(min,max);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
     [HttpGet("getcarsdetails")]
     public IActionResult GetCarsDetails()
        {
            var result = _carService.GetAllCarDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("getcarsbybrandidandcolorid")]
        public IActionResult GetCarsByBrandIdAndColorId(int brandId, int colorId)
        {
            var result = _carService.GetCarByBrandIdAndColorId(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }

}
