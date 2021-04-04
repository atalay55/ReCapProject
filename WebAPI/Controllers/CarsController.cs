using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
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
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyuniteprice")]
        public IActionResult GetByUnitePrice(decimal min ,decimal max)
        {
            var result = _carService.GetbyUnitePrice(min, max);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrabdId(int id)
        {
            var result = _carService.GetbyBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycarsbycolorid")]
        public IActionResult GetByCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _carService.GetDetails ();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }




    }
}
